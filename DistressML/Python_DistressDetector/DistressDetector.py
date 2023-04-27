import random as rand
import pandas as pds
import sklearn as skl
import numpy as npy
import matplotlib as mpl

from sklearn.metrics import confusion_matrix, accuracy_score

# Importing the dataset
dataset = pds.read_csv('DataSet_x1200.csv')
X = dataset.iloc[:, :-1].values
y = dataset.iloc[:, -1].values

# Here we'll encode the categorical data like country and yes/no into numerical values.
from sklearn.compose import ColumnTransformer
from sklearn.preprocessing import OneHotEncoder
from sklearn.preprocessing import LabelEncoder
# This section is for the independent variable.
# passthrough from below is used to prevent OneHotEncoding from affecting the non-categorical columns.

le = LabelEncoder()
le.fit(dataset['Gender'])


ct = ColumnTransformer(transformers=[('encoder', LabelEncoder(), [0])], remainder='passthrough')
X = npy.array(ct.fit_transform(X))

# print("Categorical data update for Matrix of Features \n", X)

print(X[0])
print(X[2])
# This section is for the dependent variable yes/no.
le = LabelEncoder()
y = le.fit_transform(y)
# print("Categorical data update for Dependent variables \n", y)
print(y)
# Splitting the dataset into the Training set and Test set
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

# Feature Scaling
from sklearn.preprocessing import StandardScaler
sc = StandardScaler()
X_train = sc.fit_transform(X_train)
X_test = sc.transform(X_test)

# -----------------------------------------------------------------------------------------------------------
#
# # Training the Logistic Regression model on the Training set
# from sklearn.linear_model import LogisticRegression
# classifier = LogisticRegression(random_state=0)
# classifier.fit(X_train, y_train)
#
# y_pred = classifier.predict(X_test)
# cm = confusion_matrix(y_test, y_pred)
# print("Logistic Regression")
# print(cm)
# print(accuracy_score(y_test, y_pred))
# print('\n')
#
# # Training the Decision Tree Classification model on the Training set
# from sklearn.tree import DecisionTreeClassifier
# classifier = DecisionTreeClassifier(criterion = 'entropy', random_state = 0)
# classifier.fit(X_train, y_train)
#
#
# y_pred = classifier.predict(X_test)
# cm = confusion_matrix(y_test, y_pred)
# print("Decision Tree")
# print(cm)
# print(accuracy_score(y_test, y_pred))
# print('\n')
#
# # Training the K-NN model on the Training set
# from sklearn.neighbors import KNeighborsClassifier
# classifier = KNeighborsClassifier(n_neighbors = 5, metric = 'minkowski', p = 2)
# classifier.fit(X_train, y_train)
#
#
# y_pred = classifier.predict(X_test)
# cm = confusion_matrix(y_test, y_pred)
# print("K-NN")
# print(cm)
# print(accuracy_score(y_test, y_pred))
# print('\n')
#
# # Training the Kernel SVM model on the Training set
# from sklearn.svm import SVC
# classifier = SVC(kernel = 'rbf', random_state = 0)
# classifier.fit(X_train, y_train)
#
#
# y_pred = classifier.predict(X_test)
# cm = confusion_matrix(y_test, y_pred)
# print("Kernel SVM")
# print(cm)
# print(accuracy_score(y_test, y_pred))
# print('\n')
#
# # Training the Naive Bayes model on the Training set
# from sklearn.naive_bayes import GaussianNB
# classifier = GaussianNB()
# classifier.fit(X_train, y_train)
#
#
# y_pred = classifier.predict(X_test)
# cm = confusion_matrix(y_test, y_pred)
# print("Naive Bayes")
# print(cm)
# print(accuracy_score(y_test, y_pred))
# print('\n')
#
# # Training the Random Forest Classification model on the Training set
# from sklearn.ensemble import RandomForestClassifier
# classifier = RandomForestClassifier(n_estimators = 10, criterion = 'entropy', random_state = 0)
# classifier.fit(X_train, y_train)
#
#
# y_pred = classifier.predict(X_test)
# cm = confusion_matrix(y_test, y_pred)
# print("Random Forest")
# print(cm)
# print(accuracy_score(y_test, y_pred))
# print('\n')


# Training the SVM model on the Training set
from sklearn.svm import SVC
classifier = SVC(kernel = 'linear', random_state = 0)
classifier.fit(X_train, y_train)


y_pred = classifier.predict(X_test)
cm = confusion_matrix(y_test, y_pred)
print("SVM")
print(cm)
print(accuracy_score(y_test, y_pred))
print('\n')

fr = ['M',55,95,197,153,69,9,100.21]
if fr[0] == 'F':
    fr[0] = 0
    fr.insert(1,1)
elif fr[0] == 'M':
    fr[0] = 1
    fr.insert(1,0)
print(fr)
# Examples:
print(classifier.predict(sc.transform([[0,55,95,197,153,69,9,100.21]])))
'''
# Making the Confusion Matrix
from sklearn.metrics import confusion_matrix, accuracy_score
y_pred = classifier.predict(X_test)
cm = confusion_matrix(y_test, y_pred)
print(cm)
print(accuracy_score(y_test, y_pred))
'''