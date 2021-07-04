<template>
  <!-- TOP Nav Bar -->
  <div class="iq-top-navbar">
    <div class="iq-navbar-custom">
      <nav class="navbar navbar-expand-lg navbar-light p-0">
        <div class="iq-menu-bt d-flex align-items-center">
          <div class="wrapper-menu" @click="miniSidebar">
            <div class="main-circle"><i class="las la-bars"></i></div>
          </div>
          <div class="iq-navbar-logo d-flex justify-content-between">
            <router-link :to="homeURL" class="header-logo">
              <img :src="logo" class="img-fluid rounded-normal" alt="logo">
              <span class="text-primary text-uppercase">Muzik</span>
            </router-link>
          </div>
        </div>
        <b-navbar-toggle target="navbarSupportedContent" class="mr-2">
          <i class="ri-menu-3-line"></i>
        </b-navbar-toggle>
        <b-collapse id="navbarSupportedContent" is-nav>
          <ul class="list-unstyled iq-menu-top d-flex justify-content-between mb-0 p-0">
            <router-link tag="li" active-class="active" :to="homeURL" exact>
              <a>Home</a>
            </router-link>
            <router-link tag="li" active-class="active" to="/latest" exact>
              <a>Latest</a>
            </router-link>
            <router-link tag="li" active-class="active" to="/albums" exact>
              <a>Albums</a>
            </router-link>
          </ul>
          <slot name="responsiveRight" />
        </b-collapse>
        <slot name="right"/>
      </nav>
    </div>
  </div>
  <!-- TOP Nav Bar END -->
</template>
<script>
import { APPNAME } from '../../../config/pluginInit'
import { mapGetters } from 'vuex'
// import HoverMenu from '../menus/HoverMenu'
// import CollapseMenu from '../menus/CollapseMenu'
export default {
  name: 'DefaultNavBar',
  props: {
    homeURL: { type: Object, default: () => ({ name: 'dashboard.home-1' }) },
    logo: { type: String, default: require('../../../assets/images/logo.png') },
    horizontal: { type: Boolean, default: false },
    items: { type: Array },
    sidebarGroupTitle: { type: Boolean, default: true }
  },
  mounted () {
    if (!this.horizontal) {
      document.addEventListener('click', this.closeSearch, true)
    }
  },
  components: {
    // HoverMenu,
    // CollapseMenu
  },
  computed: {
    ...mapGetters({
      bookmark: 'Setting/bookmarkState'
    })
  },
  data () {
    return {
      appName: APPNAME
    }
  },
  methods: {
    miniSidebar () {
      this.$emit('toggle')
    }
  }
}
</script>

<style scoped lang="scss">
  .collapse-menu{
    @media (min-width:1300px) {
      display: none;
    }
  }
  .iq-sidebar-menu .iq-menu.hover-menu{
    display: flex;
    @media (max-width:1299px){
      display: none !important;
    }
  }
</style>
