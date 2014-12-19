using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class TheFrequency2
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here

                double[] samples = line.Split(' ').Select(x => Convert.ToDouble(x)).ToArray();



                //double[] inRe = Normalize(samples);
                double[] inRe = samples;
                double[] inIm = new double[samples.Length];
                double[] outRe = new double[samples.Length];
                double[] outIm = new double[samples.Length];

                List<double> tempRe = new List<double>();
                List<double> tempIm = new List<double>();

                for (int i = 0; i < 2048; i++)
                {
                    if (i < 2000)
                    {
                        tempRe.Add(inRe[i]);
                        tempIm.Add(0);
                    }
                    else
                    {
                        tempRe.Add(0);
                        tempIm.Add(0);
                    }
                }

                double[] re = tempRe.ToArray();
                double[] im = tempIm.ToArray();


                FFT fft = new FFT(2048);
                double[] window = fft.getWindow();
                fft.fft(re, im);

                List<double> freqs = new List<double>();
                for (int x = 0; x < (re.Length/2)+1;x++ )
                {
                    freqs.Add(Math.Sqrt(Math.Pow(re[x],2) + Math.Pow(im[x],2)));
                }


                int fr = (int)((Math.Round((double)getFrequency(freqs.ToArray(), 20000.0d, 1024)/20))*10);

                //int pos = 0;
                //while (pos < 15 || pos > 200)
                //{
                //    freqs.RemoveAt(freqs.IndexOf(freqs.Max()));
                //    pos = freqs.IndexOf(freqs.Max());

                //}
                    //Console.WriteLine(getFrequency(DFT(inRe, inIm, outRe, outIm)));
                    //Console.WriteLine(DFT(inRe, inIm, outRe, outIm));

                    Console.WriteLine(fr);

                // end of code
            }

        Console.ReadLine();
    }

    public static int getFrequency(double[] dft, double sampleRate = 20000.0d, int sampleCount = 2000)
    {
        List<double> fourier = dft.ToList();
        double max = dft.Max();
        int position = fourier.IndexOf(max);
        int removed = 0;
        while (position < 15 || position > 200)
        {
            max = fourier.Max();
            position = fourier.IndexOf(max);
            fourier.RemoveAt(position);
            removed++;
        }

        double multiplier = sampleRate / (double)sampleCount;
        int frequency = (int)(Math.Round((position + Math.Round((double)removed / 2)) * multiplier) / 10) * 10;
        return frequency;
    }

    public static double[] DFT(double[] inRe, double[] inIm, double[] outRe, double[] outIm)
    {
        int n = inRe.Length;
        List<double> signalLevels = new List<double>();

        for (int k = 0; k < n; k++)
        {
            double sumRe = 0;
            double sumIm = 0;
            for (int t = 0; t < n; t++)
            {
                double angle = 2 * Math.PI * t * k / n;
                sumRe += inRe[t] * Math.Cos(angle) + inIm[t] * Math.Sin(angle);
                sumIm += -inRe[t] * Math.Sin(angle) + inIm[t] * Math.Cos(angle);
            }
            outRe[k] = sumRe;
            outIm[k] = sumIm;

            signalLevels.Add(Math.Sqrt(sumRe * sumRe + sumIm * sumIm));
        }

        return signalLevels.ToArray();       
    }

    public static double[] Normalize(double[] values, double scaleMin = 0.0d, double scaleMax = 1.0d)
    {
        double valueMax = values.Max();
        double valueMin = values.Min();
        double valueRange = valueMax - valueMin;
        double scaleRange = scaleMax - scaleMin;

        Double[] normalized = values.Select(i =>( (scaleRange * (i - valueMin)) / valueRange) + scaleMin).ToArray();

        return normalized;
    }


    public class FFT
    {
        int n, m;

        double[] cos;
        double[] sin;

        double[] window;

        public FFT(int n)
        {
            this.n = n;
            this.m = (int)(Math.Log((double)n) / Math.Log(2));

            // is n power of 2?
            if((n != 0) && ((n & (n - 1)) == 0))
            {
                cos = new double[n / 2];
                sin = new double[n / 2];

                for(int i=0;i<n/2;i++)
                {
                    cos[i] = Math.Cos(-2 * Math.PI * i / n);
                    sin[i] = Math.Sin(-2 * Math.PI * i / n);
                }

                makeWindow();
            }
        }

        private void makeWindow()
        {
            window = new double[n];
            for(int i=0; i<window.Length;i++)
            {
                window[i] = 0.42 - 0.5 * Math.Cos(2 * Math.PI * i / (n - 1)) + 0.08 * Math.Cos(4 * Math.PI * i / (n - 1));
            }
        }

        public double[] getWindow()
        {
            return window;
        }

        /***************************************************************
        * fft.c
        * Douglas L. Jones 
        * University of Illinois at Urbana-Champaign 
        * January 19, 1992 
        * http://cnx.rice.edu/content/m12016/latest/
        * 
        *   fft: in-place radix-2 DIT DFT of a complex input 
        * 
        *   input: 
        * n: length of FFT: must be a power of two 
        * m: n = 2**m 
        *   input/output 
        * x: double array of length n with real part of data 
        * y: double array of length n with imag part of data 
        * 
        *   Permission to copy and use this program is granted 
        *   as long as this header is included. 
        ****************************************************************/
        public void fft(double[] x, double[] y)
        {
            int i, j, k, n1, n2, a;
            double c, s, e, t1, t2;

            // Bit-reverse
            j = 0;
            n2 = n / 2;
            for (i = 1; i < n - 1; i++)
            {
                n1 = n2;
                while (j >= n1)
                {
                    j = j - n1;
                    n1 = n1 / 2;
                }
                j = j + n1;

                if (i < j)
                {
                    t1 = x[i];
                    x[i] = x[j];
                    x[j] = t1;
                    t1 = y[i];
                    y[i] = y[j];
                    y[j] = t1;
                }
            }

            // FFT
            n1 = 0;
            n2 = 1;

            for (i = 0; i < m; i++)
            {
                n1 = n2;
                n2 = n2 + n2;
                a = 0;

                for (j = 0; j < n1; j++)
                {
                    c = cos[a];
                    s = sin[a];
                    a += 1 << (m - i - 1);

                    for (k = j; k < n; k = k + n2)
                    {
                        t1 = c * x[k + n1] - s * y[k + n1];
                        t2 = s * x[k + n1] + c * y[k + n1];
                        x[k + n1] = x[k] - t1;
                        y[k + n1] = y[k] - t2;
                        x[k] = x[k] + t1;
                        y[k] = y[k] + t2;
                    }
                }
            }

        }
    }
}