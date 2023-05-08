## Program to build the dataset needed to train the machine learning model to detect distress.
# Note that for this project, we manually assign the Distress status as we do not have access to actual first responders from whom we can compile data.
import random
import random as rand
import pandas as pds
import numpy as npy
import matplotlib as mpl

'''The arrays below are meant to store the elements of the dataset before they are put together into a dataframe. '''
'''@G An array to store the Gender of first responder instances.'''
G = []
'''@Age An array to store the Age of first responder instances.'''
Age = []
'''@BloodOxy An array to store the Blood Oxygen levels of first responder instances.'''
BloodOxy = []
'''@HeartRate An array to store the Heartrate of first responder instances.'''
HeartRate = []
'''@sbp An array to store the Systolic Blood Pressure of first responder instances.'''
sbp = []
'''@dbp An array to store the Diastolic Blood Pressure of first responder instances.'''
dbp = []
'''@rr An array to store the Respiratory rate of first responder instances.'''
rr = []
'''@Temperature An array to store the Temperature of first responder instances.'''
Temperature = []
'''@Distress An array to store the Distress status of first responder instances.'''
Distress = []

hRange = []
sysRange = []
A = []
bo = []

for i in range(85, 205):
    if i <= 110:
        for k in range(2):
            hRange.append(i)
    elif 110 < i <= 140:
        for k in range(3):
            hRange.append(i)
    elif 140 < i:
        for k in range(5):
            hRange.append(i)
for i in range(85, 165):
    if i <= 120:
        for k in range(4):
            sysRange.append(i)
    elif 120 < i <= 140:
        for k in range(5):
            sysRange.append(i)
    elif 140 < i:
        for k in range(3):
            sysRange.append(i)
for i in range(21, 65):
    if i <= 39:
        for k in range(3):
            A.append(i)
    elif 40 <= i <= 53:
        for k in range(4):
            A.append(i)
    elif 54 <= i:
        A.append(i)
for i in range(92,101):
    if i <= 94:
        for k in range(4):
            bo.append(i)
    elif 95 <= i <= 97:
        for k in range(2):
            bo.append(i)
    elif 98 <= i:
        bo.append(i)

for i in range(13):
    random.shuffle(hRange)
    random.shuffle(sysRange)
    random.shuffle(A)

for i in range(4500):
    G.append(rand.choice(["M", "F"]))
    Age.append(rand.choice(A))
    BloodOxy.append(rand.choice(bo))

    HeartRate.append(rand.choice(hRange))

    sbp.append(rand.choice(sysRange))

    if 21 <= Age[i] <= 40:
        if 85 <= sbp[i] <= 125:
            dbp.append(npy.random.randint(55, 74))
        elif 126 <= sbp[i] <= 149:
            dbp.append(npy.random.randint(74, 87))
        elif sbp[i] > 149:
            dbp.append(npy.random.randint(87, 106))
    elif 41 <= Age[i] <= 54:
        if sbp[i] <= 124:
            dbp.append(npy.random.randint(59, 73))
        elif 125 <= sbp[i] <= 142:
            dbp.append(npy.random.randint(73, 86))
        else:
            dbp.append(npy.random.randint(86, 102))
    elif 55 <= Age[i] <= 65:
        if sbp[i] <= 119:
            dbp.append(npy.random.randint(63, 71))
        elif 120 <= sbp[i] <= 138:
            dbp.append(npy.random.randint(71, 83))
        else:
            dbp.append(npy.random.randint(83, 99))

    if BloodOxy[i] > 98:
        rr.append(npy.random.randint(19,28))
    if 98 >= BloodOxy[i] >= 95:
        rr.append(npy.random.randint(14,19))
    if 94 >= BloodOxy[i]:
        rr.append(npy.random.randint(5,14))

    Temperature.append(round(npy.random.uniform(98.71, 103.19), 2))
    Distress.append(0)

## DataFrame representing the first responder data, namely thier age, their sex, and their vitals data.
BodyStats = {
    'Gender': G,
    'Age': Age,
    'BloodOxy': BloodOxy,
    'HeartRate': HeartRate,
    'Systolic Blood Pressure': sbp,
    'Diastolic Blood Pressure': dbp,
    'Respiratory Rate': rr,
    'Temperature': Temperature,
    'Distress': Distress
}

df = pds.DataFrame(BodyStats)
print(df)
df.to_csv('DataSet_x1200.csv')
