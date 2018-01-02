namespace Common
{
    public class AccelerometerReadings
    {
        public AccelerometerReadings(int[] xValues, int[] yValues, int[] zValues)
        {
            XValues = xValues;
            YValues = yValues;
            ZValues = zValues;
        }

        public int[] XValues { get; }
        public int[] YValues { get; }
        public int[] ZValues { get; }
    }
}
