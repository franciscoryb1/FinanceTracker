import axios from "axios";

const API_URL = "https://localhost:7133/api/auth/";

interface LoginResponse {
  token: string;
}

const login = async (username: string, password: string): Promise<LoginResponse> => {
  const response = await axios.post<LoginResponse>(API_URL + "login", { username, password });
  if (response.data.token) {
    localStorage.setItem("token", response.data.token);
  }
  return response.data;
};

const logout = (): void => {
  localStorage.removeItem("token");
};

const getToken = (): string | null => {
  return localStorage.getItem("token");
};

const authService = {
  login,
  logout,
  getToken,
};

export default authService;
