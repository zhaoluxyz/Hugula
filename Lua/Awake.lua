print("---------------lua awake---------------")

local luaPath = "E:/work/Hugula/svn/trunk/Lua/"
package.path = luaPath.."?.lua"

require("const/requires")
require("Main")
