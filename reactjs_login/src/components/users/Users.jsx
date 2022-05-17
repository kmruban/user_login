import { useEffect, useState } from "react";
//import { useNavigate } from 'react-router-dom';

function Users() {
  //const navigate = useNavigate();
  const [users, setUsers] = useState([]);

  useEffect(() => {
    loadUsersData();
  }, []);

  const loadUsersData = (e) => {

    fetch(`https://localhost:5001/User/`, {
              method: 'GET',
              headers: { "Content-Type": "application/json"}
          }).then((response) => {
            return response.json();
          }).then(data => {
            setUsers(data);
          });
  }


  return (
    <div>
      <h1>View Users</h1>
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Username</th>
            <th>Password</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map((users) => (
            <tr key={users.id}>
              <td>{users.id}</td>
              <td>{users.username}</td>
              <td>{users.password}</td>
              <td>
                <a href={`users/editUser/${users.id}`}>
                  <button>Edit</button>
                </a>
                <a href={`users/deleteUser/${users.id}`}>
                  <button>Delete</button>
                </a>
              </td>
            </tr>
        ))}
        </tbody>
      </table>
    </div>
  );
};

export default Users;
