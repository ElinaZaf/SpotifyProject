<template>
  <b-container fluid>
    <b-row>
      <b-col lg="12">
        <iq-card>
          <template v-slot:body>
            <b-row>
              <b-col lg="4">
                <img :src="require('../../assets/images/dashboard/feature-album/01.png')" class="img-fluid w-100" alt="">
              </b-col>
              <b-col lg="8">
                <div class="d-flex align-items-top justify-content-between iq-music-play-detail">
                  <div class="music-detail">
                    <h3>DJ Khaled Featuring</h3>
                    <span>Edyta Gorniak</span>
                    <p class="mb-0">389382k Views</p>
                    <p>Song · 45 Plays</p>
                    <div class="d-flex align-items-center">
                      <button type="button" class="btn btn-primary iq-play mr-2">Play Music</button>
                    </div>
                  </div>
                  <div class="music-right">
                    <div class="d-flex align-items-center">
                      <div class="iq-circle mr-2 share">
                        <a href="javascript:void();"><i class="las la-share-alt-square text-primary"></i></a>
                      </div>
                      <div class="iq-circle mr-2">
                        <a href="javascript:void();"><i class="ri-heart-fill  text-primary"></i></a>
                      </div>
                      <div class="iq-circle">
                        <a href="javascript:void();"><i class="las la-download text-primary"></i></a>
                      </div>
                    </div>
                  </div>
                </div>
              </b-col>
            </b-row>
            <b-row>
              <b-col lg="12">
                <iq-card>
                  <template v-slot:body>
                    <ul class="list-unstyled iq-music-slide mb-0">
                      <li v-for="(item,index) of musicSlide" :key="index" class="mb-3">
                        <div class="d-flex justify-content-between align-items-center row">
                          <div class="media align-items-center col-10 col-md-5">
                            <div class="iq-realese-song ">
                              <a href="javascript:void(0);">
                                <img :src="item.image" class="img-border-radius avatar-60 img-fluid" alt="">
                              </a>
                            </div>
                            <div class="media-body ml-3">
                              <p class="mb-0">{{ item.title }}</p>
                              <small>{{ item.name }}</small>
                            </div>
                          </div>
                          <p class="mb-0 col-md-2 col-md-2 iq-music-time">{{ item.time }}</p>
                          <p class="mb-0 col-md-2 col-md-2 iq-musc-icone"><i class="lar la-star font-size-20"></i></p>
                          <p class="mb-0 col-2 col-md-2 iq-music-play"><i class="las la-play-circle font-size-32"></i></p>
                          <div class="iq-card-header-toolbar iq-music-drop d-flex align-items-center col-2 col-md-1">
                            <b-dropdown :id="`dropdownMenuButton${index}`" right variant="none" data-toggle="dropdown">
                              <template v-slot:button-content>
                                <span class="text-primary"><i class="ri-more-fill"></i></span>
                              </template>
                              <b-dropdown-item><i class="ri-eye-fill mr-2"></i>{{ $t('dropdown.view') }}</b-dropdown-item>
                              <b-dropdown-item><i class="ri-delete-bin-6-fill mr-2"></i>{{ $t('dropdown.delete') }}</b-dropdown-item>
                              <b-dropdown-item><i class="ri-file-download-fill mr-2"></i>{{ $t('dropdown.download') }}</b-dropdown-item>
                            </b-dropdown>
                          </div>
                        </div>
                      </li>
                    </ul>
                  </template>
                </iq-card>
              </b-col>
            </b-row>
          </template>
        </iq-card>
      </b-col>
    </b-row>
  </b-container>
</template>
<script>
import { core } from '../../config/pluginInit'
export default {
  name: 'Albums',
  components: { },
  mounted () {
    core.index()
  },
  data () {
    return {
      musicSlide: [
        {
          title: 'DJ Khaled Featuring',
          name: 'Edyta Gorniak',
          time: '9:52',
          image: require('../../assets/images/dashboard/realease-song/01.png')
        },
        {
          title: 'DJ Khaled Featuring',
          name: 'Edyta Gorniak',
          time: '9:52',
          image: require('../../assets/images/dashboard/realease-song/02.png')
        },
        {
          title: 'DJ Khaled Featuring',
          name: 'Edyta Gorniak',
          time: '9:52',
          image: require('../../assets/images/dashboard/realease-song/03.png')
        },
        {
          title: 'DJ Khaled Featuring',
          name: 'Edyta Gorniak',
          time: '9:52',
          image: require('../../assets/images/dashboard/realease-song/04.png')
        },
        {
          title: 'DJ Khaled Featuring',
          name: 'Edyta Gorniak',
          time: '9:52',
          image: require('../../assets/images/dashboard/realease-song/05.png')
        },
        {
          title: 'DJ Khaled Featuring',
          name: 'Edyta Gorniak',
          time: '9:52',
          image: require('../../assets/images/dashboard/realease-song/06.png')
        }
      ]
    }
  }
}
</script>
