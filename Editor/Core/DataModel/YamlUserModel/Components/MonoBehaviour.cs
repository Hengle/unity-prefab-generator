namespace YamlUserModel
{
    public abstract class MonoBehaviour: YamlComponentBase
    {
        public int m_Enabled { get; set; }
        public int m_EditorHideFlags { get; set; }
        public OutFileHold m_Script { get; set; }
        public string m_Name;
        public string m_EditorClassIdentifier;
    }
}
