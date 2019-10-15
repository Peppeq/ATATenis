import { SurfaceType, Forehand, Backhand } from "@/Api/PlayerController";
import { i18n } from "@/plugins/i18n";

export interface SurfaceObj {
	value: SurfaceType;
	text: string;
}

export interface ForehandObj {
	value: Forehand;
	text: string;
}

export interface BackhandObj {
	value: Backhand;
	text: string;
}

export class PlayerHelper {
	public static GetSurfaceOptions(): SurfaceObj[] {
		return [
			{
				value: SurfaceType.clay,
				text: i18n.t("surfaceType" + SurfaceType.clay).toString()
			},
			{
				value: SurfaceType.grass,
				text: i18n.t("surfaceType" + SurfaceType.grass).toString()
			},
			{
				value: SurfaceType.hard,
				text: i18n.t("surfaceType" + SurfaceType.hard).toString()
			}
		];
	}

	public static GetForeahandOptions(): ForehandObj[] {
		return [
			{
				value: Forehand.rightHanded,
				text: i18n.t("forehandType" + Forehand.rightHanded).toString()
			},
			{
				value: Forehand.leftHanded,
				text: i18n.t("forehandType" + Forehand.leftHanded).toString()
			}
		];
	}

	public static GetBackhandOptions(): BackhandObj[] {
		return [
			{
				value: Backhand.oneHanded,
				text: i18n.t("backhandType" + Backhand.oneHanded).toString()
			},
			{
				value: Backhand.twoHanded,
				text: i18n.t("backhandType" + Backhand.twoHanded).toString()
			}
		];
	}

	public static GetSurfaceTypeText(value: SurfaceType): string {
		return i18n.t("surfaceType" + value).toString();
	}

	public static GetForehandText(value: Forehand): string {
		return i18n.t("forehandType" + value).toString();
	}

	public static GetBackhandText(value: Backhand): string {
		return i18n.t("backhandType" + value).toString();
	}
}
