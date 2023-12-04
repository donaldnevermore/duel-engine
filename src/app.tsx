import { createRoot } from "react-dom/client";
import { Screen } from "./components/Screen/Screen"

const container = document.getElementById("root")
const root = createRoot(container!)
root.render(<Screen />)
