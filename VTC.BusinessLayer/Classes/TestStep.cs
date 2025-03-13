using VTC.Shared;

namespace VestasTestChallenge.Classes;

public class TestStep
{
    public Guid StepId { get; set; }
    public Guid TestId { get; set; }
    public int RotationSpeed { get; set; }
    public int Duration { get; set; }

    public TestStep(Guid testId, Guid stepId, int rotationSpeed, int duration)
    {
        TestId = testId;
        StepId = stepId;
        RotationSpeed = rotationSpeed;
        Duration = duration;
    }

    public TestStep(TestSequenceDTO testSequenceDto, Guid testId)
    {
        TestId = testId;
        StepId = Guid.NewGuid();
        RotationSpeed = testSequenceDto.SetPoint;
        Duration = testSequenceDto.Duration;
    }
}