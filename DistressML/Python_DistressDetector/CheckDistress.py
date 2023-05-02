# This is the revised CheckDistress program that contains the final implementation of the machine learning model for
# the Mobile App.
# This also contains the implementation for porting the SVM model below using ONNX to apply for the Mobile App.
# The output for this program is a newly generated .ONNX file that contains the processed Machine learning model.
import numpy as np
import pandas as pd
import numpy as npy

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

le = LabelEncoder()
le.fit(dataset['Distress'])
d = le.transform(dataset['Distress'])

# Now let's make the dataframe for a first responder

gender = pd.DataFrame(g, columns=['Gender'])
distress = pd.DataFrame(d, columns=['Distress'])

data = pd.concat([gender, dataset[['Age']], dataset[['BloodOxy']], dataset[['HeartRate']],
                  dataset[['Systolic Blood Pressure']], dataset[['Diastolic Blood Pressure']],
                  dataset[['Respiratory Rate']], dataset[['Temperature']], distress], axis=1)
print(data.head(1207))

X = data.iloc[:, :-1].values
y = data.iloc[:, -1].values

# Splitting the dataset into the Training set and Test set
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

# Training the SVM model on the Training set
from sklearn.svm import SVC
classifier = SVC(kernel='linear', random_state=0)
classifier.fit(X_train, y_train)

y_pred = classifier.predict(X_test)
cm = confusion_matrix(y_test, y_pred)
print("SVM")
print(accuracy_score(y_test, y_pred))

# Setup for the ONNX model file
ONNXModelPath = "DistressONNXModel.onnx"

num_features = 8
initial_type = [('feature_input', FloatTensorType([None, num_features]))]
onnx = convert_sklearn(classifier, initial_types=initial_type)
with open(ONNXModelPath, "wb") as f:
    f.write(onnx.SerializeToString())

# Setup for the ONNX session
session = rt.InferenceSession(ONNXModelPath)
input_name = session.get_inputs()[0].name
label_name = session.get_outputs()[0].name

pred_onnx = session.run(None, {input_name: X_train.astype(npy.float32)})[0]

fr = np.array([[1,55,95,197,153,69,9,100.21]])
z = session.run(None, {input_name:fr.astype(npy.float32)})[0]
print(z)
