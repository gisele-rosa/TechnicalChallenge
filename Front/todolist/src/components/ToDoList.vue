<template>
  <div id="app">
    <div class="head">
      <h1>To Do List</h1>
      <div class="newTask">
          <input type="text" v-model="newTask.title" placeholder="Título da Tarefa">
          <input type="text" v-model="newTask.description" placeholder="Descrição da Tarefa">
          <button @click="createToDo">Adicionar</button>
      </div>
      <ModalEdit v-if="isModalOpen" 
          @close="closeModal" 
          @edit-task="editTask" 
          :title="task.title"
          :description="task.description"
          :status="task.status"
          :id="task.id"
      ></ModalEdit>
      </div>
      <ul>
          <li v-for="(tarefa, index) in tasks" :key="index">
              <span><strong>{{ tarefa.title }}</strong> - {{ tarefa.description }}</span>
              <button :disabled="true" class="status">{{ tarefa.status }}</button>
              <button class="edit" @click="openModal(tarefa.id)">Editar</button>
              <button class="delete" @click="deleteToDo(tarefa.id)">Excluir</button>
          </li>
      </ul>
  </div>
  </template>
  
  <script>
  import { getTask, createTask, deleteTask, getTaskById } from '../services/apiService';
  import ModalEdit from './ModalEdit';

  export default {
    el: '#app',
    components: {
      ModalEdit
    },
    data() {
        return {
            newTask: {
                title: '',
                description: ''
            },
            task:{},
            tasks: [],
            isModalOpen: false
        };
    },
    methods: {
      async openModal(id) {
        try {
          const response = await getTaskById(id);
          this.task = response;
          console.log('Tarefa recuperada com sucesso:', response);
        } catch (error) {
          console.error('Erro ao buscar tarefa:', error);
        }
        this.isModalOpen = true;
      },
        closeModal() {
          this.isModalOpen = false;
        },

        async getToDo() {
          try {
            const response = await getTask();
            this.tasks = response;
          } catch (error) {
            console.error('Error get data:', error);
          }
        },

        async createToDo() {
            try {
              const response = await createTask(
                this.newTask.title, 
                this.newTask.description,
                'pendente'
                );
              console.log('Tarefa criada com sucesso:', response);
              this.getToDo();
            } catch (error) {
              console.error('Erro ao criar tarefa:', error);
            }
          },
        async deleteToDo(id) {
              try {
                const response = await deleteTask(id);
                console.log('Tarefa excluída com sucesso:', response);
                this.getToDo();
              } catch (error) {
                console.error('Erro ao excluir tarefa:', error);
            }
        },
      },
      created() {
        this.getToDo(); 
      }
  };
  </script>
 <style scoped src="../public/styles.css"></style> 
  
