import axios from 'axios';

const BASE_URL = 'http://localhost:5187';

export const getTask = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/ToDo`);
    return response.data;
  } catch (error) {
    console.error('Error get data:', error);
    throw error;
  }
};

export const getTaskById = async (id) => {
    try {
      const response = await axios.get(`${BASE_URL}/ToDo/${id}`);
      console.log('response API:', response.data);
      return response.data;
    } catch (error) {
      console.error('Error get data API:', error);
      throw error;
    }
};

export const createTask= async(title, description, status) => {
    try {
      const response = await axios.post(`${BASE_URL}/ToDo`, {
        title: title,
        description: description,
        status: status
      });
      console.log('response API:', response.data);
      return response.data;
    } catch (error) {
      console.error('Error send data:', error);
      throw error;
    }
  };

  export const deleteTask= async(id) => {
    try {
      const response = await axios.delete(`${BASE_URL}/ToDo/${id}`);
      console.log('response API:', response.data);
      return response.data;
    } catch (error) {
      console.error('Error delete data:', error);
      throw error;
    }
  };

  export const updateTask= async(id, title, description, status) => {
    try {
      const response = await axios.put(`${BASE_URL}/ToDo`, {
        id: id,
        title: title,
        description: description,
        status: status
      });
      console.log('response API:', response.data);
      return response.data;
    } catch (error) {
      console.error('Error update data API:', error);
      throw error;
    }
  }
