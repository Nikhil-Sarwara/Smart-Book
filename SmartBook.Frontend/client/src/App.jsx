import React, { useState, useEffect } from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./pages/Home";
import Books from "./pages/Books";
import About from "./pages/About";
import Authentication from "./pages/Authentication";
import { useAuth } from "./contexts/AuthContext";

const ProtectedRoute = ({ children }) => {
  const auth = useAuth();
  const [user, setUser] = useState(null);

  useEffect(() => {
    setUser(auth.user);
  }, [auth.user]);

  return user ? children : <Navigate to="/authentication" />;
};

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route
            path="books"
            element={
              <ProtectedRoute>
                <Books />
              </ProtectedRoute>
            }
          />
          <Route path="about" element={<About />} />
          <Route path="authentication" element={<Authentication />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
