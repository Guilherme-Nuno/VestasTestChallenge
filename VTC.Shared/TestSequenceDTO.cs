namespace VTC.Shared;

public class TestSequenceDTO
{
    public int SetPoint { get; set; }
    public int Duration { get; set; }

    public TestSequenceDTO(int setPoint, int duration)
    {
        SetPoint = setPoint;
        Duration = duration;
    }
}