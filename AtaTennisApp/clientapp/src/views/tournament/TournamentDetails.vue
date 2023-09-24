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
							v-model="tournament.name"
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
							v-model="tournament.place"
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
						:value="dateHelper.getDateByLocale(tournament.startTime, $i18n.locale)"
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
								v-model="tournament.startTime"
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
						:value="dateHelper.getDateByLocale(tournament.endTime, $i18n.locale)"
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
								v-model="tournament.endTime"
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
						:value="tournamentHelper.GetTournamentCategoryName(tournament.category)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Category"
						v-model="tournament.category"
						:options="tournamentHelper.GetTournamentCategories()"
						:value="tournament.category"
					/>
				</d-col>

				<!-- PlayingSystem -->
				<d-col md="6" class="form-group">
					<label for="PlayingSystem">PlayingSystem</label>
					<d-form-input
						v-if="isReadonly"
						id="PlayingSystem"
						:readonly="isReadonly"
						:value="tournamentHelper.GetPlayingSystemName(tournament.playingSystem)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="PlayingSystem"
						v-model="tournament.playingSystem"
						:options="tournamentHelper.GetPlayingSystems()"
						:value="tournament.playingSystem"
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
						:value="tournamentHelper.GetTournamentTypeName(tournament.tournamentType)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Category"
						v-model="tournament.tournamentType"
						:options="tournamentHelper.GetTournamentTypes()"
						:value="tournament.tournamentType"
					/>
				</d-col>

				<!-- Surface -->
				<d-col md="6" class="form-group">
					<label for="Surface">Surface</label>
					<d-form-input
						v-if="isReadonly"
						id="Surface"
						:readonly="isReadonly"
						:value="playerHelper.GetSurfaceTypeText(tournament.surface)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Surface"
						v-model="tournament.surface"
						:options="playerHelper.GetSurfaceOptions()"
						:value="tournament.surface"
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
						:value="tournamentHelper.GetBallsTypeName(tournament.ballsType)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Category"
						v-model="tournament.ballsType"
						:options="tournamentHelper.GetBallsTypes()"
						:value="tournament.ballsType"
					/>
				</d-col>

				<!-- Surface -->
				<d-col md="6" class="form-group">
					<label for="Surface">Surface</label>
					<d-form-input
						v-if="isReadonly"
						id="Surface"
						:readonly="isReadonly"
						:value="playerHelper.GetSurfaceTypeText(tournament.surface)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Surface"
						v-model="tournament.surface"
						:options="playerHelper.GetSurfaceOptions()"
						:value="tournament.surface"
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
import { ValidationObserver } from "vee-validate";
import { DateHelper } from "../../common/DateHelper";
// import TournamentClient, {
//   TournamentDTO,
//   TournamentCategory,
//   TournamentType,
//   PlayingSystem
// } from "../../Api/TournamentController";
import { TournamentHelper } from "./tournamentHelper";
import { PlayerHelper } from "../player/player-helper";
import { TournamentDTO } from "@/Api/dtos/TournamentDTO";
import { PlayingSystem } from "@/Api/enums/PlayingSystem";
import { TournamentCategory } from "@/Api/enums/TournamentCategory";
import { TournamentType } from "@/Api/enums/TournamentType";
import { TournamentClient } from "@/Api/TournamentController";

@Component
export default class TournamentDetails extends BaseComponentClass {
	@Prop({ default: false }) readonly isCreateOrEdit!: boolean;
	@Prop({ default: null }) readonly tournamentProp: TournamentDTO;
	@Prop() readonly hideModal: () => void;
	@Prop({
	  default: null
	}) readonly modifyTournament: (tournament: TournamentDTO) => void;

	tournament: TournamentDTO = null;
	@Watch("tournamentProp")
	onTournamentPropChange(tournamentProp: TournamentDTO): void {
	  this.tournament = tournamentProp;
	}

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

	async addOrEditTournament(): Promise<void> {
	  if (await this.tournamentForm.validate()) {
	    const client = new TournamentClient();
	    this.tryGetDataByArgs<null, TournamentDTO>({
	      apiMethod: client.addOrEditTournament,
	      showError: true,
	      requestArgs: this.tournament
	    }).then((resp) => {
	      if (resp.ok) {
	        NotificationUtils.ShowSuccess({
	          message: "Parada ulozene",
	          title: "Tournament"
	        });
	        this.tournamentForm.reset();
	        // if (this.modifyTournament != null) {
	        // 	this.modifyTournament(this.tournament);
	        // 	this.hideModal();
	        // }
	      }
	    });
	  }
	}

	@Ref() tournamentForm!: InstanceType<typeof ValidationObserver>;

	isTournamentNameValid(changed: boolean, validated: boolean, valid: boolean): boolean {
	  if (this.isEdit) {
	    return changed ? valid : null;
	  } else {
	    return changed || validated ? valid : null;
	  }
	}

	isTournamentPlaceValid(changed: boolean, validated: boolean, valid: boolean): boolean {
	  if (this.isEdit) {
	    return changed ? valid : null;
	  } else {
	    return changed || validated ? valid : null;
	  }
	}

	created(): void {
	  this.tournament = new TournamentDTO();
	  if (this.tournamentProp != null) {
	    this.tournament = { ...this.tournamentProp };
	  } else {
	    this.tournament.id = 0;
	    this.tournament.category = TournamentCategory.singles;
	    this.tournament.tournamentType = TournamentType.ata;
	    this.tournament.playingSystem = PlayingSystem.prince;
	  }
	  this.isReadonly = !this.isCreateOrEdit;
	  this.isEdit = this.isCreateOrEdit && this.tournamentProp != null;
	}
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-details.scss";
</style>
