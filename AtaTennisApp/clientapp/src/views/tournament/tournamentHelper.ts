import { TournamentType, TournamentCategory, SurfaceType, PlayingSystem, BallsType } from "@/Api/TournamentController";
import { i18n } from "@/plugins/i18n";

export interface TournamentTypeObj {
	value: TournamentType;
	text: string;
}

export interface TournamentCategoryObj {
	value: TournamentCategory;
	text: string;
}

export interface PlayingSystemObj {
	value: PlayingSystem;
	text: string;
}

export interface BallsTypeObj {
	value: BallsType;
	text: string;
}

export class TournamentHelper {
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
		];
	}

	public static GetTournamentTypesWithAll(): TournamentTypeObj[] {
		const types = this.GetTournamentTypes();
		types.push({
			value: null,
			text: i18n.t("all").toString()
		});
		return types;
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

	public static GetPlayingSystems(): PlayingSystemObj[] {
		return [
			{
				value: PlayingSystem.complete,
				text: i18n.t("playingSystem" + PlayingSystem.complete).toString()
			},
			{
				value: PlayingSystem.prince,
				text: i18n.t("playingSystem" + PlayingSystem.prince).toString()
			},
			{
				value: PlayingSystem.kombi,
				text: i18n.t("playingSystem" + PlayingSystem.kombi).toString()
			},
			{
				value: PlayingSystem.group,
				text: i18n.t("playingSystem" + PlayingSystem.group).toString()
			}
		];
	}

	public static GetBallsTypes(): BallsTypeObj[] {
		return [
			{
				value: BallsType.dunlop,
				text: "Dunlop"
			},
			{
				value: BallsType.slazenger,
				text: "Slazenger"
			}
		];
	}

	public static GetBallsTypeName(id?: BallsType): string {
		return id != null ? i18n.t("ballsType" + id).toString() : "";
	}

	public static GetPlayingSystemName(id?: PlayingSystem): string {
		return id != null ? i18n.t("playingSystem" + id).toString() : "";
	}

	public static GetTournamentTypeName(id?: TournamentType): string {
		return id != null ? i18n.t("tournamentType" + id).toString() : "";
	}

	public static GetTournamentCategoryName(id?: TournamentCategory): string {
		return id != null ? i18n.t("tournamentCategory" + id).toString() : "";
	}

	public static GetTournamentSurfaceName(id?: SurfaceType): string {
		return id != null ? i18n.t("surfaceType" + id).toString() : "";
	}
}
