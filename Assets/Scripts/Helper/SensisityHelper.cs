public static class SensisityHelper
{
	private const float SOURCE_SENS_MULTI = 0.44f;

	private const float OW_SENS_MULTI = 0.132f;

	private const float SOURCE_TO_OVERWATCH = 3.33333325f;

	private const double SOURCE_TO_SIEGE = 3.8095238208770752;

	private const double SOURCE_TO_SIEGE_ADS = 39.523811340332031;

	private const float SOURCE_TO_FORTNITE = 0.04f;

	public static float UnityToSource(float unitySens)
	{
		return unitySens / SOURCE_SENS_MULTI;
	}
	public static float SourceToUnity(float sourceSens)
	{
		return sourceSens * SOURCE_SENS_MULTI;
	}

	public static float UnityToOverwartch(float unitySens)
	{
		return unitySens / OW_SENS_MULTI;
	}

	public static float OverwatchToUnity(float overwatchSens)
	{
		return overwatchSens * OW_SENS_MULTI;
	}

}
