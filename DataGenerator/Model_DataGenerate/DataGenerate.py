import random
import random as rand
import pandas as pds
# import sklearn as skl
import numpy as npy
import matplotlib as mpl

'''
G = [rand.choice(["M", "F"])]
Age = [npy.random.randint(21, 69)]
BloodOxy = [npy.random.randint(92, 100)]
HeartRate = [npy.random.randint(75, 185)]
sbp = [npy.random.randint(75, 200)]
dbp = [npy.random.randint(40, 110)]
rr = [npy.random.randint(5, 28)] # range btwn 5 and 29
Temperature = [round(npy.random.uniform(96.51, 103.19), 2)]
'''

G = []
Age = []
BloodOxy = []
HeartRate = []
sbp = []
dbp = []
rr = []
Temperature = []
Distress = []

hRange = []
sysRange = []
A = []  # age
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

    # Heartrate
    HeartRate.append(rand.choice(hRange))
    '''
    if 21 <= Age[i] <= 36:
        sbp.append(npy.random.randint(55, 74))
    elif 37 <= Age[i] <= 49:
        HeartRate.append(rand.choice(hRange))
    elif 50 <= Age[i] <= 69:
        HeartRate.append(rand.choice(hRange))
    '''
    # Blood pressure - both systolic and diastolic
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

    # rr.append(npy.random.randint(5, 28))

    if BloodOxy[i] > 98:
        rr.append(npy.random.randint(19,28))
    if 98 >= BloodOxy[i] >= 95:
        rr.append(npy.random.randint(14,19))
    if 94 >= BloodOxy[i]:
        rr.append(npy.random.randint(5,14))

    Temperature.append(round(npy.random.uniform(98.71, 103.19), 2))
    Distress.append(0)

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
'''
print(len(G))
print(len(Age))
print(len(BloodOxy))
print(len(HeartRate))
print(len(sbp))
print(len(dbp))
print(len(rr))
print(len(Temperature))
'''
df = pds.DataFrame(BodyStats)

print(df)
# df.to_csv('D:\GitHubDesktopRepos\CI-FirstResponders\DistressML\DataSet.csv')
df.to_csv('Data5.csv')
# data = pds.read_csv('Data2.csv')
# data.drop(data.columns[0], axis=1)
