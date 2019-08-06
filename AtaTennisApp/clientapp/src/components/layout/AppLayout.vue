<template>
    <d-container fluid>
        <!-- <d-row> -->
        <!-- Main Sidebar -->
        <!-- <main-sidebar :items="sidebarItems" /> -->
        <!-- <d-col class="main-content offset-lg-2 offset-md-3 p-0" tag="main" cols="12" lg="10" md="6" sm="11"> -->
        <!-- <div id="nav">
                    <router-link to="/">Home</router-link> |
                    <router-link to="/about">About</router-link> |
                    <router-link to="/players">Players</router-link>
                </div> -->

        <d-row>
            <d-col>
                <!-- Main Navbar -->
                <main-navbar />

            </d-col>
        </d-row>
        <d-row>
            <d-col>
                <!-- Content -->
                <div class="content-wrapper">
                    <slot />
                </div>
            </d-col>
        </d-row>
        <!-- Main Footer -->
        <!-- <main-footer /> -->
        <!-- </d-col>
            <d-col cols="12" md="4" sm="1">
                <slot/>
            </d-col> -->
        <!-- </d-row> -->
    </d-container>
</template>

<script lang="ts">
    import mainNavbar from './main-navbar.vue';
    import { Component, Vue } from 'vue-property-decorator';

    @Component({
        components: { mainNavbar }
    })
    export default class AppLayout extends Vue {
        data() {
            return {
                center: "flex-start"
            }
        }
    }
</script>
