<template>
	<div id="app">
		<app-layout>
			<router-view />
		</app-layout>
		<notifications group="error" position="top center" />
		<!-- <notifications group="foo" position="top center" classes="notification-class"/> -->
	</div>
</template>
