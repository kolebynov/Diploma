public struct GroupData
{
    public int groupId;
    public string groupName;
    public short groupTypeId;

    public GroupData(int groupId, string groupName, short groupTypeId)
    {
        this.groupId = groupId;
        this.groupName = groupName;
        this.groupTypeId = groupTypeId;
    }
}
