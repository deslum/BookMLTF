using System;
using static Tensorflow.Binding;
using NumSharp;

namespace Example10
{
    class Program
    {
        static void Main()
        {
            var rawData = np.random.normal(10, 1, 100);

            var alpha = tf.constant(0.05f);

            var currValue = tf.placeholder(tf.float32);

            var prevAvg = tf.Variable(0f);

            var updateAvg = alpha * currValue + (1f - alpha) * prevAvg;

            var init = tf.global_variables_initializer();

            using (var sess = tf.Session())
            {
                sess.run(init);

                foreach (var data in rawData)
                {
                    var currAvg = sess.run(updateAvg, (currValue, Convert.ToSingle(data)));
                    sess.run(prevAvg.assign(currAvg));
                    Console.WriteLine($"CurrentValue {data} CurrentAverage {currAvg}");
                }
            }
        }
    }
}