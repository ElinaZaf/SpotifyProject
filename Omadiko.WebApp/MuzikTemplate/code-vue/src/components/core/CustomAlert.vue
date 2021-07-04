<template>
  <b-modal body-class="p-0" modal-class="compose-popup modal-sticky-bottom-right modal-sticky-lg iq-delete-modal" content-class="iq-all-popup-box" :ref="modalRef" :id="modalId" v-bind:hide-footer="true" v-bind:hide-header="true">
    <div class="iq-card">
      <div class="iq-card-body pt-2">
        <div class="row">
          <div class="col-12 p-0 text-right">
            <button type="button" class="close-popup btn-transprent" data-dismiss="modal">
              <img :src="require('../../assets/images/icon/icon-modal-close.svg')" @click.prevent="hideModal" class="img-fluid" alt="notification-close">
            </button>
          </div>
        </div>
        <div class="row">
          <div class="col-12 p-0 text-center">
            <h5 class=""><b>Confirm Deletion</b></h5>
          </div>
        </div>
        <button type="button" @click.prevent="confirmModal" class="btn btn-red w-100 mt-4 p-2">Delete</button>
      </div>
    </div>
  </b-modal>
</template>
<script>
export default {
  name: 'CustomAlert',
  props: ['modalId', 'modalRef'],
  methods: {
    hideModal () {
      this.$emit('clicked', false)
      this.$refs[this.modalRef].hide()
    },
    confirmModal (event) {
      this.$emit('clicked', true)
      this.$refs[this.modalRef].hide()
    }
  }
}
</script>
