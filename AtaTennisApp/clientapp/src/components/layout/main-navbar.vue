<template>
<d-navbar toggleable="md" type="dark" theme="primary" >
    <d-navbar-toggle target="nav-collapse"></d-navbar-toggle>
    <d-navbar-brand tag="a" to="/" >
        <!-- <d-nav-item > -->
            <h6 class="text-white my-auto mr-4">ATA Tenis</h6>
        <!-- </d-nav-item> -->
    </d-navbar-brand>
    <d-collapse is-nav id="nav-collapse">   
        <d-navbar-nav v-bind:justified="true" >  
            <d-nav-item to="/">Turnaje</d-nav-item>
            <d-nav-item to="/" >Rebríčky</d-nav-item>
            <d-nav-item to="/players" >Hráči</d-nav-item>
        </d-navbar-nav>
    </d-collapse>
</d-navbar>
</template>

<script>
export default {
    name: 'main-navbar',
    data () {
return {
    navbarIsJustified: true
}
    }
}
</script>
