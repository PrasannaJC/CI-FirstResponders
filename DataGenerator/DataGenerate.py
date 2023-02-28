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

heartRange = []
sysRange = []

for i in range(85, 205):
    if i <= 110:
        for k in range(6):
            heartRange.append(i)
    elif 110 < i <= 140:
        for k in range(3):
            heartRange.append(i)
    elif 140 < i:
        heartRange.append(i)
for i in range(85, 165):
    if i <= 120:
        for k in range(6):
            sysRange.append(i)
    elif 120 < i <= 140:
        for k in range(3):
            sysRange.append(i)
    elif 140 < i:
        sysRange.append(i)


for i in range(500):
    G.append(rand.choice(["M", "F"]))
    Age.append(npy.random.randint(21, 69))
    BloodOxy.append(npy.random.randint(92, 100))

    # Heartrate
    if 21 <= Age[i] <= 36:
        HeartRate.append(npy.random.randint(heartRange))
    elif 37 <= Age[i] <= 49:
        HeartRate.append(npy.random.randint(heartRange))
    elif 50 <= Age[i] <= 68:
        HeartRate.append(npy.random.randint(heartRange))
    # Blood pressure - both systolic and diastolic
    sbp.append(npy.random.randint(sysRange))

    if 21 <= Age[i] <= 40:
        if 85 <= sbp[i] <= 125:
            dbp.append(npy.random.randint(55, 74))
        elif 126 <= sbp[i] <= 149:
            dbp.append(npy.random.randint(75, 88))
        elif sbp[i] > 149:
            dbp.append(npy.random.randint(89, 105))
    elif 41 <= Age[i] <= 56:
        if sbp[i] <= 124:
            dbp.append(npy.random.randint(59, 73))
        elif 125 <= sbp[i] <= 142:
            dbp.append(npy.random.randint(74, 86))
        else:
            dbp.append(npy.random.randint(87, 99))
    elif 57 <= Age[i] <= 68:
        if sbp[i] <= 119:
            dbp.append(npy.random.randint(63, 71))
        elif 120 <= sbp[i] <= 138:
            dbp.append(npy.random.randint(72, 83))
        else:
            dbp.append(npy.random.randint(84, 96))

    rr.append(npy.random.randint(5, 28))
    Temperature.append(round(npy.random.uniform(96.51, 103.19), 2))

BodyStats = {
    'Gender': G,
    'Age': Age,
    'BloodOxy': BloodOxy,
    'HeartRate': HeartRate,
    'Systolic Blood Pressure': sbp,
    'Diastolic Blood Pressure': dbp,
    'Respiratory Rate': rr,
    'Temperature': Temperature
}
print(len(G))
print(len(Age))
print(len(BloodOxy))
print(len(HeartRate))
print(len(sbp))
print(len(dbp))
print(len(rr))
print(len(Temperature))


df = pds.DataFrame(BodyStats)

print(df)
df.to_csv('D:\GitHubDesktopRepos\CI-FirstResponders\DistressML\DataSet.csv')

# data = pds.read_csv('Data.csv')
# data.drop(data.columns[0], axis=1)
