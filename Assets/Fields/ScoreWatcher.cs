public class ScoreWatcher : FieldWatcher
{
    public override string Value()
    {
        return Game.Instance().Score.ToString();
    }
}
