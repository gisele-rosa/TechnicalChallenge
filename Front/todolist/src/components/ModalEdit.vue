<template>
    <div class="modal">
      <div class="modal-content">
        <h2>Adicionar Tarefa</h2>
        <div class="modal-edit">
            <div class="input-row">
                <label for="title">Título:</label>
                <input type="text" id="title" v-model="task.title">
            </div>
            <div class="input-row">
                <label for="description">Descrição:</label>
                <input id="description" v-model="task.description">
            </div>
            <div class="input-row">
                <label for="status">Status:</label>
                <select id="status" v-model="task.status">
                    <option value="pendente">Pendente</option>
                    <option value="em_andamento">Em andamento</option>
                    <option value="concluída">Concluída</option>
                </select>
            </div>
        </div>
        <button class="btn-edit" @click="editTask">Editar</button>
        <button class="btn-close" @click="close">Cancelar</button>
      </div>
    </div>
  </template>
  
  <script>
  import { updateTask } from '../services/apiService';

  export default {
    props: {
    title: {
      type: String,
      default: ''
    },
    description: {
      type: String,
      default: ''
    },
    status: {
      type: String,
      default: ''
    },
    id: {
      type: String,
    }
  },
    data() {
      return {
        task: {
            title: this.title,
            description: this.description,
            status: this.status,
            id: this.id
        }
      };
    },
    methods: {
      close() {
        this.$emit('close');
      },
      async editTask() {
        try {
            const response = await updateTask(this.id, this.title, this.description, this.status);
        } catch (error) {
            console.error('Erro ao atualizar tarefa:', error);
        }
      }
    }
  };
  </script>
  <style scoped src="../public/styles.css"></style> 
  
  