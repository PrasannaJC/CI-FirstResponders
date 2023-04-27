using MonitoringSuiteLibrary.Models;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace MonitoringSuiteLibrary.MachineLearning
{
    public class CheckDistressONNX
    {
        public static bool GetDistressStatus(int age, char sex, Vitals v)
        {
            string ONNXModelPath = Path.GetFullPath(Path.Join("MachineLearning", "DistressONNXModel.onnx"));
            int sexF = 0;
            bool r = false;
            if (sex == 'F')
                sexF = 0;
            else if (sex == 'M')
                sexF = 1;

            var inputTensor = new DenseTensor<float>(new float[]{ sexF, age, v.BloodOxy, 
                v.HeartRate, v.SysBP, v.DiaBP, v.RespRate, v.TempF }, new int[] {1, 8});

            var input = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor<float>("feature_input", inputTensor) };

            var session = new InferenceSession(ONNXModelPath);

            var output = session.Run(input);

            var result = output.ToArray()[1].AsTensor<float>().ToArray<float>()[1];

            if (result <= 0)
                r = true;
            else if (result > 0)
                r = false;

            return r;
        }
    }
}
