﻿namespace KerbalHealth
{
    public class ConnectedFactor : HealthFactor
    {
        public override string Name => "Connected";

        public override double BaseChangePerDay => HighLogic.CurrentGame.Parameters.CustomParams<KerbalHealthFactorsSettings>().ConnectedFactor;

        public override double ChangePerDay(ProtoCrewMember pcm)
        {
            if (Core.IsInEditor) return IsEnabledInEditor() ? BaseChangePerDay : 0;
            return (Core.IsKerbalLoaded(pcm) && (Core.KerbalVessel(pcm).Connection != null) && Core.KerbalVessel(pcm).Connection.IsConnectedHome) ? BaseChangePerDay : 0;
        }
    }
}
