using System;
using static Tensorflow.Binding;


namespace Example8
{
    class Program
    {
        static void Main()
        {
            var a = new [,]{{1f,2f}};
            var x = tf.constant(a);
            var negativeMatrix = tf.negative(x);
            
            using (var sess  = tf.Session())
            {
                var result = sess.run(negativeMatrix);
                Console.WriteLine(result.ToString());
            }
        }
    }
}