using System.Collections;
using System.Collections.Generic;

public static class Utils
{
    //Its an outrage i cant use generics!!!!
    public static float SumArray(float[] array, int start, int end)
    {
        float sum = 0;

        for (int i = start; i < end; i++)
        {
            sum += array[i];
        }

        return sum;
    }


}

