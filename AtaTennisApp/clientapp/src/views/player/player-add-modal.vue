<template>
	<d-modal v-if="showModal" :size="modalSize" @close="hideModal">
		<d-modal-header>
			<d-modal-title>{{ $t("newPlayer") }}</d-modal-title>
		</d-modal-header>
		<d-modal-body>
			<player-bio :is-create="true"></player-bio>
		</d-modal-body>
	</d-modal>
</template>

<script lang="ts">
import Component from "vue-class-component";
import Vue from "vue";
import { Prop } from "vue-property-decorator";
import PlayerBio from "./player-bio.vue";

@Component({
	components: { PlayerBio }
})
export default class PlayerAddModal extends Vue {
	@Prop({ default: false }) readonly showModal!: boolean;
	@Prop({ default: "lg" }) readonly modalSize!: string;
	@Prop() readonly hideModal: () => void;
}
</script>
