<template>
	<aside :class="['main-sidebar', 'col-12', 'col-md-3', 'col-lg-2', 'px-0', sidebarVisible ? 'open' : '']">
		<div class="main-navbar">
			<nav class="navbar align-items-stretch navbar-light bg-white flex-md-nowrap border-bottom p-0">
				<router-link class="navbar-brand w-100 mr-0" to="/" style="line-height: 25px;">
					<div class="d-table m-auto">
						<img
							id="main-logo"
							class="d-inline-block align-top mr-1"
							style="max-width: 25px;"
							src="@/assets/logo.png"
							alt="ATATenis"
						/>
						<span v-if="!hideLogoText" class="d-none d-md-inline ml-1">ATATenis</span>
					</div>
				</router-link>
				<a class="toggle-sidebar d-sm-inline d-md-none d-lg-none" @click="handleToggleSidebar()">
					<i class="material-icons">&#xE5C4;</i>
				</a>
			</nav>
		</div>

		<div class="nav-wrapper">
			<d-nav class="flex-column">
				<li class="nav-item dropdown">
					<d-link class="nav-link" to="/dashboard/playerManagement">
						<div class="item-icon-wrapper" />
						<span>Player Management</span>
					</d-link>
				</li>
				<li class="nav-item dropdown">
					<d-link class="nav-link" to="/dashboard/tournamentManagement">
						<div class="item-icon-wrapper" />
						<span>Tournament Management</span>
					</d-link>
				</li>
			</d-nav>
		</div>
	</aside>
</template>

<script>
export default {
	name: "MainSidebar",
	props: {
		/**
		 * Whether to hide the logo text, or not.
		 */
		hideLogoText: {
			type: Boolean,
			default: false
		}
		// /**
		//  * The menu items.
		//  */
		// items: {
		// 	type: Array,
		// 	required: true
		// }
	},
	data() {
		return {
			sidebarVisible: false
		};
	},
	created() {
		this.$eventHub.$on("toggle-sidebar", this.handleToggleSidebar);
	},
	beforeDestroy() {
		this.$eventHub.$off("toggle-sidebar");
	},
	methods: {
		handleToggleSidebar() {
			this.sidebarVisible = !this.sidebarVisible;
		}
	}
};
</script>

<style lang="scss">
.main-sidebar {
	.item-icon-wrapper {
		display: inline-block;
	}
	.dropdown-menu {
		display: block;
	}
	.nav-link:hover {
		cursor: pointer;
	}
}
</style>
