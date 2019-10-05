<template>
	<sidebar-menu :menu="menu" />
</template>

<script lang="ts">
import Component from "vue-class-component";
import Vue from "vue";

@Component
export default class MainSidebar extends Vue {
	menu: {}[] = [
		{
			header: true,
			title: "Main Navigation",
			hiddenOnCollapse: true
		},
		{
			href: "/dashboard",
			title: "Dashboard",
			icon: "fa fa-user"
		},
		{
			href: "/charts",
			title: "Charts",
			icon: "fa fa-chart-area",
			child: [
				{
					href: "/charts/sublink",
					title: "Sub Link"
				}
			]
		}
	];
}
</script>

<style lang="scss" scoped>
@import "@/styles/components/layouts/main-sidebar.scss";
</style>
