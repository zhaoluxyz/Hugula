print("---------------lua awake---------------")

local luaPath = "E:/work/Hugula/Lua/"
package.path = luaPath.."?.lua"

require("const/requires")
require("Main")
