<template>
	<ValidationObserver ref="tournamentForm">
		<d-form v-if="tournament != null">
			<d-form-row v-if="!isReadonly">
				<!-- Name -->
				<d-col md="6" class="form-group">
					<label for="name">{{ $t("name") }}</label>
					<ValidationProvider
						ref="tournamentName"
						v-slot="{ errors, changed, validated, valid, invalid }"
						rules="required"
						:name="$t('name')"
					>
						<d-form-input
							id="name"
							v-model="tournament.Name"
							:state="isTournamentNameValid(changed, validated, valid)"
						/>
						<span
							id="error"
							class="error"
							:class="{ 'form-group': errors != null && errors.length > 0 }"
							:v-if="changed && invalid"
							>{{ errors[0] }}</span
						>
					</ValidationProvider>
				</d-col>

				<!-- Place -->
				<d-col md="6" class="form-group">
					<label for="place">{{ $t("place") }}</label>
					<ValidationProvider
						v-slot="{ errors, changed, validated, valid, invalid }"
						rules="required"
						:name="$t('place')"
					>
						<d-form-input
							id="place"
							v-model="tournament.Place"
							:state="isTournamentPlaceValid(changed, validated, valid)"
						/>
						<span
							id="error"
							class="error"
							:class="{ 'form-group': errors != null && errors.length > 0 }"
							:v-if="changed && invalid"
							>{{ errors[0] }}</span
						>
					</ValidationProvider>
				</d-col>
			</d-form-row>
			<d-form-row v-if="!isReadonly">
				<!-- StartTime -->
				<d-col md="6" class="form-group">
					<label for="StartTime">{{ $t("start") }}</label>
					<d-form-input
						v-if="isReadonly"
						id="Birthdate"
						:readonly="isReadonly"
						:value="dateHelper.getDateByLocale(tournament.StartTime, $i18n.locale)"
					/>
					<ValidationProvider
						v-slot="{ errors, changed, validated, valid, invalid }"
						rules="required"
						:name="$t('start')"
					>
						<d-input-group style="width: 100%">
							<d-input-group-text slot="append">
								<i class="material-icons">calendar_today</i>
							</d-input-group-text>
							<d-datepicker
								v-if="!isReadonly"
								v-model="tournament.StartTime"
								class="tournament-date"
								:input-class="[{ 'is-invalid': validated && invalid }, 'form-control']"
								typeable
							/>
						</d-input-group>
						<span
							id="error"
							class="error"
							:class="{ 'form-group': errors != null && errors.length > 0 }"
							:v-if="changed && invalid"
							>{{ errors[0] }}</span
						>
					</ValidationProvider>
				</d-col>

				<!-- EndTime -->
				<d-col md="6" class="form-group">
					<label for="EndTime">{{ $t("end") }}</label>
					<d-form-input
						v-if="isReadonly"
						id="EndTime"
						:readonly="isReadonly"
						:value="dateHelper.getDateByLocale(tournament.EndTime, $i18n.locale)"
					/>
					<ValidationProvider
						v-slot="{ errors, changed, validated, valid, invalid }"
						rules="required"
						:name="$t('end')"
					>
						<d-input-group style="width: 100%">
							<d-input-group-text slot="append">
								<i class="material-icons">calendar_today</i>
							</d-input-group-text>
							<d-datepicker
								v-if="!isReadonly"
								v-model="tournament.EndTime"
								class="tournament-date"
								:input-class="[{ 'is-invalid': validated && invalid }, 'form-control']"
								typeable
							/>
						</d-input-group>
						<span
							id="error"
							class="error"
							:class="{ 'form-group': errors != null && errors.length > 0 }"
							:v-if="changed && invalid"
							>{{ errors[0] }}</span
						>
					</ValidationProvider>
				</d-col>
			</d-form-row>
			<d-form-row>
				<!-- Category -->
				<d-col md="6" class="form-group">
					<label for="Category">Category</label>
					<d-form-input
						v-if="isReadonly"
						id="Category"
						:readonly="isReadonly"
						:value="tournamentHelper.GetTournamentCategoryName(tournament.Category)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Category"
						v-model="tournament.Category"
						:options="tournamentHelper.GetTournamentCategories()"
						:value="tournament.Category"
					/>
				</d-col>

				<!-- PlayingSystem -->
				<d-col md="6" class="form-group">
					<label for="PlayingSystem">PlayingSystem</label>
					<d-form-input
						v-if="isReadonly"
						id="PlayingSystem"
						:readonly="isReadonly"
						:value="tournamentHelper.GetPlayingSystemName(tournament.PlayingSystem)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="PlayingSystem"
						v-model="tournament.PlayingSystem"
						:options="tournamentHelper.GetPlayingSystems()"
						:value="tournament.PlayingSystem"
					/>
				</d-col>
			</d-form-row>

			<d-form-row>
				<!-- Type -->
				<d-col md="6" class="form-group">
					<label for="Type">Type</label>
					<d-form-input
						v-if="isReadonly"
						id="Type"
						:readonly="isReadonly"
						:value="tournamentHelper.GetTournamentTypeName(tournament.TournamentType)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Category"
						v-model="tournament.TournamentType"
						:options="tournamentHelper.GetTournamentTypes()"
						:value="tournament.TournamentType"
					/>
				</d-col>

				<!-- Surface -->
				<d-col md="6" class="form-group">
					<label for="Surface">Surface</label>
					<d-form-input
						v-if="isReadonly"
						id="Surface"
						:readonly="isReadonly"
						:value="playerHelper.GetSurfaceTypeText(tournament.Surface)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Surface"
						v-model="tournament.Surface"
						:options="playerHelper.GetSurfaceOptions()"
						:value="tournament.Surface"
					/>
				</d-col>
			</d-form-row>
			<d-form-row>
				<!-- BallsType -->
				<d-col md="6" class="form-group">
					<label for="Type">BallsType</label>
					<d-form-input
						v-if="isReadonly"
						id="BallsType"
						:readonly="isReadonly"
						:value="tournamentHelper.GetBallsTypeName(tournament.BallsType)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Category"
						v-model="tournament.BallsType"
						:options="tournamentHelper.GetBallsTypes()"
						:value="tournament.BallsType"
					/>
				</d-col>

				<!-- Surface -->
				<d-col md="6" class="form-group">
					<label for="Surface">Surface</label>
					<d-form-input
						v-if="isReadonly"
						id="Surface"
						:readonly="isReadonly"
						:value="playerHelper.GetSurfaceTypeText(tournament.Surface)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Surface"
						v-model="tournament.Surface"
						:options="playerHelper.GetSurfaceOptions()"
						:value="tournament.Surface"
					/>
				</d-col>
			</d-form-row>
			<d-button v-if="!isReadonly" theme="primary" @click.prevent="addOrEditTournament">
				{{ !isEdit ? $t("create") : $t("saveChanges") }}
			</d-button>
		</d-form>
	</ValidationObserver>
</template>

<script lang="ts">
import Component from "vue-class-component";
import { Prop, Watch, Ref } from "vue-property-decorator";
import { BaseComponentClass } from "../../common/BaseComponentClass";
import { NotificationUtils } from "../../common/notification";
import { ValidationProvider, ValidationObserver } from "vee-validate";
import { DateHelper } from "../../common/DateHelper";
import TournamentClient, {
	TournamentDTO,
	TournamentCategory,
	TournamentType,
	PlayingSystem
} from "../../Api/TournamentController";
import { TournamentHelper, TournamentCategoryObj } from "./tournamentHelper";
import { PlayerHelper } from "../player/player-helper";

@Component
export default class TournamentDetails extends BaseComponentClass {
	@Prop({ default: false }) readonly isCreateOrEdit!: boolean;
	@Prop({ default: null }) readonly tournamentProp: TournamentDTO;
	@Prop() readonly hideModal: () => void;
	@Prop({ default: null }) readonly modifyTournament: (tournament: TournamentDTO) => void;

	tournament: TournamentDTO = null;
	isReadonly = true;
	isEdit = false;
	calendarIcon = '<i class="material-icons">calendar_today</i>';

	tournamentHelper = TournamentHelper;
	playerHelper = PlayerHelper;

	getBirthdateText(date: Date): string {
		if (date != null) {
			console.log(date);

			return DateHelper.getDateByLocale(date, this.$i18n.locale);
		} else {
			return "";
		}
	}

	getDateFormat(): string {
		if (this.$i18n.locale == "sk") {
			return "dd.MMM.yyyy";
		} else {
			return "MMM.dd.yyyy";
		}
	}

	async addOrEditTournament() {
		if (await this.tournamentForm.validate()) {
			const client = new TournamentClient();
			this.tryGetDataByArgs<null, TournamentDTO>({
				apiMethod: client.addOrEditTournament,
				showError: true,
				requestArgs: this.tournament
			}).then(resp => {
				if (resp.ok) {
					if (this.modifyTournament != null) {
						this.modifyTournament(this.tournament);
						this.hideModal();
						NotificationUtils.ShowSuccess({
							message: "Parada ulozene",
							title: "Tournament"
						});
					}
				}
			});
		}
	}

	@Ref() tournamentForm!: InstanceType<typeof ValidationObserver>;

	isTournamentNameValid(changed: boolean, validated: boolean, valid: boolean) {
		if (this.isEdit) {
			return changed ? valid : null;
		} else {
			return changed || validated ? valid : null;
		}
	}

	isTournamentPlaceValid(changed: boolean, validated: boolean, valid: boolean) {
		if (this.isEdit) {
			return changed ? valid : null;
		} else {
			return changed || validated ? valid : null;
		}
	}

	mounted() {
		this.tournament = new TournamentDTO();
		if (this.tournamentProp != null) {
			this.tournament = { ...this.tournamentProp };
		} else {
			this.tournament.Id = 0;
			// resolve issue why ts file is compiled in isolation and therefore not available const enums
			this.tournament.Category = 0; //TournamentCategory.singles;
			this.tournament.TournamentType = 1; //TournamentType.ata;
			this.tournament.PlayingSystem = 1; // PlayingSystem.prince;
		}
		this.isReadonly = !this.isCreateOrEdit;
		this.isEdit = this.isCreateOrEdit && this.tournamentProp != null;
	}
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-details.scss";
</style>
