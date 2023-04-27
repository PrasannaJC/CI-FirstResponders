import random as rand

import numpy as np
import pandas as pd
import numpy as npy
import matplotlib as mpl

from sklearn.metrics import confusion_matrix, accuracy_score
from skl2onnx import convert_sklearn
from skl2onnx.common.data_types import FloatTensorType
import onnxruntime as rt

# Importing the dataset
dataset = pd.read_csv('DataSet_x1200.csv')

# Here we'll encode the categorical data - that being Gender and Distress Status.
from sklearn.preprocessing import LabelEncoder

le = LabelEncoder()
le.fit(dataset['Gender'])
g = le.transform(dataset['Gender'])

# print("Before Encoding:", list(dataset['Gender'][-10:]))
# print("After Encoding:", g[-10:])
# print("The inverse from the encoding result:", le.inverse_transform(g[-10:]))

le = LabelEncoder()
le.fit(dataset['Distress'])
d = le.transform(dataset['Distress'])

# print("Before Encoding:", list(dataset['Distress'][-10:]))
# print("After Encoding:", d[-10:])
# print("The inverse from the encoding result:", le.inverse_transform(d[-10:]))

# -----------------------------------------------------------------------------------------------------------
# Now let's make the dataframe for a first responder

gender = pd.DataFrame(g, columns=['Gender'])
distress = pd.DataFrame(d, columns=['Distress'])

data = pd.concat([gender, dataset[['Age']], dataset[['BloodOxy']], dataset[['HeartRate']],
                  dataset[['Systolic Blood Pressure']], dataset[['Diastolic Blood Pressure']],
                  dataset[['Respiratory Rate']], dataset[['Temperature']], distress], axis=1)
# print(data.shape)
print(data.head(1207))

# -----------------------------------------------------------------------------------------------------------
X = data.iloc[:, :-1].values
y = data.iloc[:, -1].values

# Splitting the dataset into the Training set and Test set
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

# -----------------------------------------------------------------------------------------------------------

# Training the SVM model on the Training set
from sklearn.svm import SVC
classifier = SVC(kernel='linear', random_state=0)
classifier.fit(X_train, y_train)

y_pred = classifier.predict(X_test)
# print(y_pred)
cm = confusion_matrix(y_test, y_pred)
print("SVM")
# print(cm)
print(accuracy_score(y_test, y_pred))
# print('\n')

# -----------------------------------------------------------------------------------------------------------
# setup the onnx model file

ONNXModelPath = "DistressONNXModel.onnx"

num_features = 8
initial_type = [('feature_input', FloatTensorType([None, num_features]))]
onnx = convert_sklearn(classifier, initial_types=initial_type)
with open(ONNXModelPath, "wb") as f:
    f.write(onnx.SerializeToString())

# -----------------------------------------------------------------------------------------------------------
# setup the onnx session

session = rt.InferenceSession(ONNXModelPath)
input_name = session.get_inputs()[0].name
label_name = session.get_outputs()[0].name

# print(X_train[0])
pred_onnx = session.run(None, {input_name: X_train.astype(npy.float32)})[0]
# print(pred_onnx)

fr = np.array([[1,55,95,197,153,69,9,100.21]])
z = session.run(None, {input_name:fr.astype(npy.float32)})[0]
print(z)
#
# fr = np.array([[1,34,98,165,113,72,18,99.01]])
# z = session.run(None, {input_name:fr.astype(npy.float32)})[0]
# print(z)
