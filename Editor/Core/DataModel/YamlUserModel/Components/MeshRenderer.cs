namespace YamlUserModel
{
    public class MeshRenderer: YamlComponentBase
    {
        public int m_Enabled { get; set; }
        public int m_CastShadows { get; set; }
        public int m_ReceiveShadows { get; set; }
        public int m_MotionVectors { get; set; }
        public int m_LightProbeUsage { get; set; }
        public int m_ReflectionProbeUsage { get; set; }
        public OutFileHold[] m_Materials { get; set; }
        public StaticBatchInfo m_StaticBatchInfo { get; set; }
        public InFileHold m_StaticBatchRoot { get; set; }
        public InFileHold m_ProbeAnchor { get; set; }
        public InFileHold m_LightProbeVolumeOverride { get; set; }
        public int m_ScaleInLightmap { get; set; }
        public int m_PreserveUVs { get; set; }
        public int m_IgnoreNormalsForChartDetection { get; set; }
        public int m_ImportantGI { get; set; }
        public int m_SelectedEditorRenderState { get; set; }
        public int m_MinimumChartSize { get; set; }
        public float m_AutoUVMaxDistance { get; set; }
        public float m_AutoUVMaxAngle { get; set; }
        public InFileHold m_LightmapParameters { get; set; }
        public int m_SortingLayerID { get; set; }
        public int m_SortingLayer { get; set; }
        public int m_SortingOrder { get; set; }
    }
}
