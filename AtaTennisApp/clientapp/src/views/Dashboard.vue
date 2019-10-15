<template>
	<d-container fluid class="main-content-container px-4">
		<d-row class="px-4 py-2">
			<h3>Dashboard</h3>
		</d-row>
		<d-row class="p-4">
			<d-form class="main-navbar__search w-100 d-none d-md-flex d-lg-flex">
				<d-input-group class="ml-3" seamless>
					<d-input-group-text slot="prepend">
						<!-- <i class="material-icons">search</i> -->
						<i class="fas fa-search"></i>
					</d-input-group-text>
					<d-input class="navbar-search" placeholder="Search for player..." />
				</d-input-group>
			</d-form>
		</d-row>
		<d-row class="p-4">
			<d-button @click="addPlayer">Add player</d-button>
		</d-row>
		<player-add-modal :show-modal="showAddPlayerModal" :hide-modal="hideAddPlayerModal"></player-add-modal>
	</d-container>
</template>

<script lang="ts">
import { BaseComponentClass } from "../common/BaseComponentClass";
import Component from "vue-class-component";
import PlayerAddModal from "./player/player-add-modal.vue";

@Component({
	components: { PlayerAddModal }
})
export default class Dashboard extends BaseComponentClass {
	showAddPlayerModal: boolean = false;

	hideAddPlayerModal() {
		this.showAddPlayerModal = false;
	}

	addPlayer() {
		this.showAddPlayerModal = true;
		console.log("added player");
	}
}
</script>

<style></style>
