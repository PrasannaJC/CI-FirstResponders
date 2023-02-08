import random as rand
import pandas as pds
import sklearn as skl
import numpy as npy
import matplotlib as mpl

G = [rand.choice(["M", "F"])]
Age = [npy.random.randint(21, 69)]
BloodOxy = [npy.random.randint(92, 100)]
HeartRate = [npy.random.randint(75, 185)]
Temperature = [round(npy.random.uniform(96.51, 103.19), 2)]

for i in range(499):
    G.append(rand.choice(["M", "F"]))
    Age.append(npy.random.randint(21, 69))
    BloodOxy.append(npy.random.randint(92, 100))
    HeartRate.append(npy.random.randint(75, 185))
    Temperature.append(round(npy.random.uniform(96.51, 103.19), 2))

BodyStats = {
    'Gender': G,
    'Age': Age,
    'BloodOxy': BloodOxy,
    'HeartRate': HeartRate,
    'Temperature': Temperature
}

df = pds.DataFrame(BodyStats)

print(df)
df.to_csv('Data.csv')

# data = pds.read_csv('Data.csv')
# data.drop(data.columns[0], axis=1)
