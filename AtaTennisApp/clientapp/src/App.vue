<template>
	<div id="app">
		<app-layout>
			<router-view />
		</app-layout>
		<notifications group="error" position="top center" />
		<!-- <notifications group="foo" position="top center" classes="notification-class"/> -->
		<!-- <div class="container" style="background: blue; color: white">
			container2
			<div class="row" style="background: green; color: white; width: 100%">row</div>
		</div> -->
	</div>
</template>
