using System;
using System.Collections.Generic;

[Serializable]
public class NoteData
{
    public int timeDS; // deciseconds
    public int lane;
}

[Serializable]
public class ChartData
{
    public List<NoteData> notes;
}
