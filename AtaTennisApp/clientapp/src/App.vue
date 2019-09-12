<template>
    <div id="app">
        <app-layout>
            <router-view />
        </app-layout>
        <notifications group="error" position="top center" />
        <!-- <notifications group="foo" position="top center" classes="notification-class"/> -->
    </div>
</template>

<style>
#app {
    /* font-family: 'Avenir', Helvetica, Arial, sans-serif; */
    font-family: "Poppins", -apple-system, BlinkMacSystemFont, "Segoe UI",
        Roboto, "Helvetica Neue", Arial, sans-serif;

    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
}

#nav {
    padding: 30px;
}

#nav a {
    font-weight: bold;
    color: #2c3e50;
}

#nav a.router-link-exact-active {
    color: #42b983;
}

div.notifications {
    top: 78px !important;
}

.vue-notification-template {
    border-radius: 5px;
}

.notification-error {
    background-color: aqua;
}

@import "App.css";
</style>
