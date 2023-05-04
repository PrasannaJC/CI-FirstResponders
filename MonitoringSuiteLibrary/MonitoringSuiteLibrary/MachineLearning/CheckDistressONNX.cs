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
    /// <summary>
    /// The new class that uses the python ONNX machine learning implementation to check the distress status of first responders.
    /// This references the DistressONNXModel.onnx file as it's source for the machine learning model.
    /// </summary>
    public class CheckDistressONNX
    {
        /// <summary>
        /// Check the distress status of a First Responder object using it's age, gender, and vitals data.
        /// </summary>
        /// <param name="age">The first responders age id.</param>
        /// <param name="sex">The first responders gender.</param>
        /// <param name="v">The first responders Vitals data.</param>
        /// <returns>Returns a boolean representing the distress status of a first responder.</returns>
        public static bool GetDistressStatus(int age, char sex, Vitals v, string path)
        {
            // comment for debugging
            // string ONNXModelPath = Path.GetFullPath(Path.Join("MachineLearning", "DistressONNXModel.onnx"));            
            // string ONNXModelPath = Path.GetFullPath(Path.Combine("data", "user", "0", "com.frs.mobilevitalsmonitoringtool", "files", ".local", "share", "DistressONNXModel.onnx"));

            string ONNXModelPath = Path.GetFullPath(path);

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
