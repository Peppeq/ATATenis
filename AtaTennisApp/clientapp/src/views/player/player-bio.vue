<template>
	<ValidationObserver ref="playerForm">
		<d-form v-if="player != null">
			<d-form-row v-if="!isReadonly">
				<!-- Name -->
				<d-col md="6" class="form-group">
					<label for="name">{{ $t("name") }}</label>
					<ValidationProvider
						ref="playerName"
						v-slot="{ errors, changed, validated, valid, invalid }"
						rules="required"
						:name="$t('name')"
					>
						<d-form-input
							id="name"
							v-model="player.Name"
							:state="isPlayerNameValid(changed, validated, valid)"
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

				<!-- Surname -->
				<d-col md="6" class="form-group">
					<label for="surname">{{ $t("surname") }}</label>
					<ValidationProvider
						ref="playerSurname"
						v-slot="{ errors, changed, validated, valid, invalid }"
						rules="required"
						:name="$t('surname')"
					>
						<d-form-input
							id="surname"
							v-model="player.Surname"
							:state="isPlayerSurnameValid(changed, validated, valid)"
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

			<d-form-row>
				<!-- BirthDate -->
				<d-col md="6" class="form-group">
					<label for="BirthDate">{{ $t("age") }}</label>
					<d-form-input
						v-if="isReadonly"
						id="Birthdate"
						:readonly="isReadonly"
						:value="dateHelper.getDateByLocale(player.BirthDate, $i18n.locale)"
					/>
					<d-datepicker v-if="!isReadonly" v-model="player.BirthDate" typeable />
					<!-- <d-form-input
						id="Birthdate"
						v-model="player.BirthDate"
						:v-if="false"
						type="date"
						:value="player.BirthDate"
					/> -->
				</d-col>

				<!-- residence -->
				<d-col md="6" class="form-group">
					<label for="residence">{{ $t("residence") }}</label>
					<!-- <d-form-input id="residence" :readonly="true" :value="player.Residence" /> -->
					<d-form-input
						id="residence"
						v-model="player.Residence"
						:readonly="isReadonly"
						:value="player.Residence"
						:class="{ 'player-input': isReadonly }"
					/>
				</d-col>
			</d-form-row>

			<d-form-row>
				<!-- Height -->
				<d-col md="6" class="form-group">
					<label for="height">{{ $t("height") }}</label>
					<d-form-input
						id="height"
						v-model="player.Height"
						type="number"
						:readonly="isReadonly"
						:value="player.Height"
						:class="{ 'player-input': isReadonly }"
					/>
				</d-col>

				<!-- Weight -->
				<d-col md="6" class="form-group">
					<label for="weight">{{ $t("weight") }}</label>
					<d-form-input
						id="weight"
						v-model="player.Weight"
						type="number"
						:readonly="isReadonly"
						:value="player.Weight"
						class="player-input"
					/>
				</d-col>
			</d-form-row>

			<d-form-row>
				<!-- Forehand -->
				<d-col md="6" class="form-group">
					<label for="forehand">Forehand</label>
					<d-form-input
						v-if="isReadonly"
						id="forehand"
						:readonly="isReadonly"
						:value="playerHelper.GetForehandText(player.Forehand)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="forehand"
						v-model="player.Forehand"
						:options="playerHelper.GetForeahandOptions()"
						:value="player.Forehand"
					/>
				</d-col>

				<!-- Backhand -->
				<d-col md="6" class="form-group">
					<label for="Backhand">Backhand</label>
					<d-form-input
						v-if="isReadonly"
						id="Backhand"
						:readonly="isReadonly"
						:value="playerHelper.GetBackhandText(player.Backhand)"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="Backhand"
						v-model="player.Backhand"
						:options="playerHelper.GetBackhandOptions()"
						:value="player.Backhand"
					/>
				</d-col>
			</d-form-row>

			<d-form-row>
				<!-- Favourite Surface -->
				<d-col md="6" class="form-group">
					<label for="favSurface">{{ $t("favSurface") }}</label>
					<d-form-input
						v-if="isReadonly"
						:readonly="isReadonly"
						:value="playerHelper.GetSurfaceTypeText(player.Surface)"
						:class="{ 'player-input': isReadonly }"
					/>
					<d-form-select
						v-if="!isReadonly"
						id="favSurface"
						v-model="player.Surface"
						:options="playerHelper.GetSurfaceOptions()"
						:value="player.Surface"
					/>
				</d-col>

				<!-- Favourite Atp Player -->
				<d-col md="6" class="form-group">
					<label for="favAtpPlayer">{{ $t("favAtpPlayer") }}</label>
					<d-form-input
						id="favAtpPlayer"
						v-model="player.FavouritePlayer"
						:readonly="isReadonly"
						:value="player.FavouritePlayer"
						class="player-input"
					/>
				</d-col>
			</d-form-row>
			<d-form-row v-show="isReadonly">
				<!-- Titels -->
				<d-col md="6" class="form-group">
					<label for="titles">{{ $tc("title", 2) }}</label>
					<d-form-input id="titles" :readonly="isReadonly" :value="player.TitlesCount" class="player-input" />
				</d-col>

				<!-- Finalist -->
				<d-col md="6" class="form-group">
					<label for="finalist">{{ $t("finalist") }}</label>
					<d-form-input
						id="finalist"
						:readonly="isReadonly"
						:value="player.FinalistCount"
						class="player-input"
					/>
				</d-col>
			</d-form-row>
			<d-form-row>
				<!-- tournaments -->
				<d-col v-if="isReadonly" md="6" class="form-group">
					<label for="tournaments">{{ $tc("tournament", 2) }}</label>
					<d-form-input
						id="tournaments"
						:readonly="isReadonly"
						:value="player.TournamentCount"
						class="player-input"
					/>
				</d-col>

				<!-- racquet -->
				<d-col md="6" class="form-group">
					<label for="racquet">{{ $t("racquet") }}</label>
					<d-form-input
						id="racquet"
						v-model="player.Racquet"
						:readonly="isReadonly"
						:value="player.Racquet"
						:class="{ 'player-input': isReadonly }"
					/>
				</d-col>
			</d-form-row>
			<d-button v-if="!isReadonly" theme="primary" @click.prevent="addOrEditPlayer">
				{{ !isEdit ? $t("create") : $t("saveChanges") }}
			</d-button>
		</d-form>
	</ValidationObserver>
</template>

<script lang="ts">
import Component from "vue-class-component";
import { Prop, Ref } from "vue-property-decorator";
import PlayerClient, { PlayerDTO } from "@/Api/PlayerController";
import { PlayerHelper } from "../player/player-helper";
import { BaseComponentClass } from "../../common/BaseComponentClass";
import { NotificationUtils } from "../../common/notification";
import { ValidationProvider, ValidationObserver } from "vee-validate";

@Component
export default class PlayerBio extends BaseComponentClass {
	@Prop({ default: false }) readonly isCreateOrEdit!: boolean;
	// @Prop({ default: false }) readonly isEdit!: boolean;
	@Prop({ default: null }) readonly playerProp: PlayerDTO;
	@Prop() readonly hideModal: () => void;
	@Prop({ default: null }) modifyPlayer: (player: PlayerDTO) => void;

	player: PlayerDTO = null;
	isReadonly = true;
	playerSurnameAfterRender: InstanceType<typeof ValidationProvider> = null;
	isEdit = false;
	playerHelper = PlayerHelper;

	async addOrEditPlayer(): Promise<void> {
	  if (await this.playerForm.validate()) {
	    const client = new PlayerClient();
	    this.tryGetDataByArgs<null, PlayerDTO>({
	      apiMethod: client.addOrEditPlayer,
	      showError: true,
	      requestArgs: this.player
	    }).then(() => {
	      if (this.modifyPlayer != null) {
	        this.modifyPlayer(this.player);
	      }
	      this.hideModal();
	      NotificationUtils.ShowSuccess({
	        message: "Parada ulozene",
	        title: "Player"
	      });
	      console.log("player saved");
	    });
	  }
	}

	@Ref() playerForm!: InstanceType<typeof ValidationObserver>;

	isPlayerNameValid(changed: boolean, validated: boolean, valid: boolean): boolean {
	  if (this.isEdit) {
	    return changed ? validated : null;
	  } else {
	    return changed || validated ? valid : null;
	  }
	}

	isPlayerSurnameValid(changed: boolean, validated: boolean, valid: boolean): boolean {
	  if (this.isEdit) {
	    return changed ? valid : null;
	  } else {
	    return changed || validated ? valid : null;
	  }
	}

	mounted(): void {
	  this.player = new PlayerDTO();
	  if (this.playerProp != null) {
	    this.player = { ...this.playerProp };
	  } else {
	    this.player.Id = 0;
	    this.player.Points = 0;
	  }
	  this.isReadonly = !this.isCreateOrEdit;
	  this.isEdit = this.isCreateOrEdit && this.playerProp != null;
	}
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/player/player.scss";
</style>
