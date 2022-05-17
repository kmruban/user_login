import './app.scss';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Register from './components/Register.jsx';
import Login from './components/Login.jsx';
import Nav from './components/Nav.jsx';
import Users from './components/users/Users.jsx';
import EditUser from './components/users/EditUser.jsx';
import DeleteUser from './components/users/DeleteUser.jsx';
import Home from './components/Home.jsx';

function App() {
  return (
    <Router>
      <div className="app">
        <Nav />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />}/>
          <Route path="/register" element={<Register />}/>
          <Route path="/home" element={<Home />} />
          <Route path="/users" element={<Users />} />
          <Route path="/users/editUser/:id" element={<EditUser />} />
          <Route path="/users/deleteUser/:id" element={<DeleteUser />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
