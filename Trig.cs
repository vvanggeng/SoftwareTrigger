using System;
using System.Collections;


public class Trig
{
    int M = 1000; //触发前采样点数M
    int N = 3000; //触发后采样点数N
    double[] buffer1 = new double[80000]; //触发后数据存储buffer1
    Queue buffer2 = new Queue(); //触发前数据存储buffer2
    bool istrig = false; //软件触发标志
    double volt = 1;//触发阈值
    int data = 0; //数据采集系统读入的数据 此处用0代替。


    public Trig()
	{
        
	}

    //数据采集系统读入数据
    private void datainput(doulble[] buffer)
    {
        TrigBefore(buffer2, data);//维持buffer2

        //判断阈值
        if (data>volt)
        {
            istrig = true;//置触发标志

            //数据写入buffer1
            for (int i = 0; i < N; i++) 
            {
                buffer[i] = data;
            }

            buffer2.CopyTo(buffer1, 0);//合并两组数据 得到M+N
        }

    }


    //维持buffer2大小为N
    private void TrigBefore(Queue queue, double data)
    {
        queue.Enqueue(data);
        if (queue.Count == (8 * pretrignum + 9))
        {
            queue.Dequeue();
        }
    }

}
