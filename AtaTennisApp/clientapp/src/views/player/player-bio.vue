<template>
	<d-form v-if="player != null">
		<d-form-row v-if="!isReadonly">
			<!-- Name -->
			<d-col md="6" class="form-group">
				<label for="name">{{ $t("name") }}</label>
				<d-form-input id="name" v-model="player.Name" />
			</d-col>

			<!-- Surname -->
			<d-col md="6" class="form-group">
				<label for="surname">{{ $t("surname") }}</label>
				<!-- <d-form-input id="residence" :readonly="true" :value="player.Residence" /> -->
				<d-form-input id="surname" v-model="player.Surname" />
			</d-col>
		</d-form-row>

		<d-form-row>
			<!-- Age -->
			<d-col md="6" class="form-group">
				<label for="age">{{ $t("age") }}</label>
				<d-form-input
					id="age"
					v-model="player.Age"
					:readonly="isReadonly"
					:value="player.Age"
					:class="{ 'player-input': isReadonly }"
				/>
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
					:value="getForehandText(player.Forehand)"
				/>
				<d-form-select
					v-if="!isReadonly"
					id="forehand"
					v-model="player.Forehand"
					:options="forehandOptions"
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
					:value="getBackhandText(player.Backhand)"
				/>
				<d-form-select
					v-if="!isReadonly"
					id="Backhand"
					v-model="player.Backhand"
					:options="backhandOptions"
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
					:value="getSurfaceTypeText(player.Surface)"
					:class="{ 'player-input': isReadonly }"
				/>
				<d-form-select
					v-if="!isReadonly"
					id="favSurface"
					v-model="player.Surface"
					:options="surfaceTypeOptions"
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
				<d-form-input id="finalist" :readonly="isReadonly" :value="player.FinalistCount" class="player-input" />
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
		<d-button v-if="!isReadonly" theme="primary">{{ isCreate ? $t("create") : $t("saveChanges") }}</d-button>
	</d-form>
</template>

<script lang="ts">
import Component from "vue-class-component";
import Vue from "vue";
import { Prop, Watch } from "vue-property-decorator";
import { PlayerDTO, Backhand, Forehand } from "@/Api/PlayerController";
import { PlayerHelper, SurfaceObj, ForehandObj, BackhandObj } from "../player/player-helper";
import { SurfaceType } from "../../Api/PlayerController";

@Component
export default class PlayerBio extends Vue {
	@Prop({ default: false }) readonly isCreate!: boolean;
	@Prop({ default: false }) readonly isEdit!: boolean;
	@Prop({ default: null }) readonly playerProp: PlayerDTO;
	player: PlayerDTO = null;
	isReadonly: boolean = true;
	surfaceTypeOptions: SurfaceObj[] = [];
	forehandOptions: ForehandObj[] = [];
	backhandOptions: BackhandObj[] = [];

	getSurfaceTypeText(value: SurfaceType): string {
		return PlayerHelper.GetSurfaceTypeText(value);
	}

	getForehandText(value: Forehand): string {
		return PlayerHelper.GetForehandText(value);
	}

	getBackhandText(value: Backhand): string {
		return PlayerHelper.GetBackhandText(value);
	}

	@Watch("$i18n.locale")
	onLocaleChanged() {
		this.surfaceTypeOptions = PlayerHelper.GetSurfaceOptions();
		this.forehandOptions = PlayerHelper.GetForeahandOptions();
		this.backhandOptions = PlayerHelper.GetBackhandOptions();
	}

	mounted() {
		this.surfaceTypeOptions = PlayerHelper.GetSurfaceOptions();
		this.forehandOptions = PlayerHelper.GetForeahandOptions();
		this.backhandOptions = PlayerHelper.GetBackhandOptions();
		if (this.playerProp != null) {
			this.player = this.playerProp;
		} else {
			this.player = new PlayerDTO();
			console.log("new player initialized");
			console.log(this.player);
		}
		this.isReadonly = !this.isCreate && !this.isEdit;
	}
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/player/player.scss";
</style>
