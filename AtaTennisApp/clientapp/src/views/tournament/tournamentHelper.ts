import { TournamentType, Tournament } from "@/Api/TournamentController";
import { i18n } from "@/plugins/i18n";
import { TournamentCategory } from "@/Api/PlayerController";

export interface TournamentTypeObj {
	value: TournamentType;
	text: string;
}

export interface TournamentCategoryObj {
	value: TournamentCategory;
	text: string;
}

export class TournamentHelperClass {
	public static GetTournamentTypes(): TournamentTypeObj[] {
		return [
			{
				value: TournamentType.grandslam,
				text: i18n.t("tournamentType" + TournamentType.grandslam).toString()
			},
			{
				value: TournamentType.ata,
				text: i18n.t("tournamentType" + TournamentType.ata).toString()
			},
			{
				value: TournamentType.challanger,
				text: i18n.t("tournamentType" + TournamentType.challanger).toString()
			},
			{
				value: TournamentType.ataSpecial,
				text: i18n.t("tournamentType" + TournamentType.ataSpecial).toString()
			},
			{
				value: TournamentType.challangerSpecial,
				text: i18n.t("tournamentType" + TournamentType.challangerSpecial).toString()
			}
			// {
			// 	value: TournamentType.all,
			// 	text: i18n.t("allValues").toString()
			// },
		];
	}

	public static GetTournamentCategories(): TournamentCategoryObj[] {
		return [
			{
				value: TournamentCategory.singles,
				text: i18n.t("tournamentCategory" + TournamentCategory.singles).toString()
			},
			{
				value: TournamentCategory.doubles,
				text: i18n.t("tournamentCategory" + TournamentCategory.doubles).toString()
			}
		];
	}
}

export function GetTournamentTypeName(id: number): string {
	return i18n.t("tournamentType" + id).toString();
}

export function GetTournamentCategoryName(id: number): string {
	return i18n.t("tournamentCategory" + id).toString();
}

export function GetTournamentSurfaceName(id: number): string {
	return i18n.t("surfaceType" + id).toString();
}
