<template>
	<d-modal v-if="showModal" :size="modalSize" @close="hideModal">
		<d-modal-header>
			<d-modal-title>{{ $t("newTournament") }}</d-modal-title>
		</d-modal-header>
		<d-modal-body>
			<tournament-details
				:is-create-or-edit="true"
				:hide-modal="hideModal"
				:tournament-prop="tournament"
				:modify-tournament="modifyTournament"
			></tournament-details>
		</d-modal-body>
	</d-modal>
</template>

<script lang="ts">
import Component from "vue-class-component";
import Vue from "vue";
import { Prop } from "vue-property-decorator";
import TournamentDetails from "./TournamentDetails.vue";
import { TournamentDTO } from "@/Api/TournamentController";

@Component({
  components: { TournamentDetails }
})
export default class TournamentModal extends Vue {
	@Prop({ default: false }) readonly showModal!: boolean;
	@Prop({ default: "lg" }) readonly modalSize!: string;
	@Prop({ default: null }) readonly tournament!: TournamentDTO;
	@Prop({
	  default: null
	}) readonly modifyTournament!: (tournament: TournamentDTO) => void;
	@Prop() readonly hideModal: () => void;
}
</script>
