public static class ArrowInputState
{
    public static ArrowData activeArrow;

    public static void SetActiveArrow(ArrowData arrow)
    {
        activeArrow = arrow;
    }

    public static void ClearIfThisArrow(ArrowData arrow)
    {
        if (activeArrow == arrow)
            activeArrow = null;
    }
}
