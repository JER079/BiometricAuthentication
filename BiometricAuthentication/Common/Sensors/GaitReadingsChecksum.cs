namespace BiometricAuthentication.Common.Sensors
{
    public class GaitReadingsChecksum
    {
        public int[] Positions { get; }
        public double Checksum { get; }

        public GaitReadingsChecksum(int[] positions, double checksum)
        {
            Positions = positions;
            Checksum = checksum;
        }
    }
}
