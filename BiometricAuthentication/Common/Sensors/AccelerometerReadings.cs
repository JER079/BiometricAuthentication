namespace BiometricAuthentication.Common.Sensors
{
    public class AccelerometerReadings
    {
        public AccelerometerReadings(double[] xValues, double[] yValues, double[] zValues)
        {
            XValues = xValues;
            YValues = yValues;
            ZValues = zValues;
        }

        public double[] XValues { get; }
        public double[] YValues { get; }
        public double[] ZValues { get; }
    }
}
