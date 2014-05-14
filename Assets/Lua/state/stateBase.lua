StateBase=class(function(self,itemObjects)
        self.m_itemList={}
        if itemObjects then self.m_itemList = itemObjects end
    end)

local StateBase = StateBase

function StateBase:getItemCount()
    local itemList = self.m_itemList
    local size = #itemList
    return size
end

function StateBase:addItem(obj)
    local itemList = self.m_itemList
    for i, v in ipairs(itemList) do
        if(v == obj) then
            print("obj is exist in current state ")
           return
        end
    end
    table.insert(self.m_itemList, obj)
end

function StateBase:removeItem(obj)
    local itemList = self.m_itemList
    for i, v in ipairs(itemList) do
        if(v == obj) then
            table.remove(itemList,i)
            if obj.hide~=nil then obj:hide() end
            if(obj.onRemoveFromState~=nil) then
                obj:onRemoveFromState(self)
            end
        end
    end
end

function StateBase:onFocus(previousState)
    local itemList = self.m_itemList
    local size = #itemList
    for i = size, 1, -1 do
        local v = itemList[i]
        if v.onFocus then v:onFocus(previousState) end
    end
end

function StateBase:onBlur(newState)
    local itemList = self.m_itemList
    local size = #itemList
    for i = size, 1, -1 do
        local v = itemList[i]
        if v.onBlur then v:onBlur(newState) end
    end
end

function StateBase:clear( ... )
    local itemList = self.m_itemList
    local size = #itemList
    for i = size, 1, -1 do
        local v = itemList[i]
        if v.clear then v:clear() end
    end
end

function StateBase:onClick(sender,arg)
    local itemList = self.m_itemList
    local size = #itemList
    for i = size, 1, -1 do
        local v = itemList[i]
        if v.onClick then v:onClick(sender,arg) end
    end
end

function StateBase:onPress(sender,arg)
    local itemList = self.m_itemList
    local size = #itemList
    for i = size, 1, -1 do
        local v = itemList[i]
        if v.onPress then v:onPress(sender,arg) end
    end
    return true
end

function StateBase:onDrag(sender,arg)
    local itemList = self.m_itemList
    local size = #itemList
    for i = size, 1, -1 do
        local v = itemList[i]
        if v.onDrag then v:onDrag(sender,arg) end
    end
    return true
end

function StateBase:onDrop(sender,arg)
    local itemList = self.m_itemList
    local size = #itemList
    for i = size, 1, -1 do
        local v = itemList[i]
        if v.onDrop then v:onDrop(sender,arg) end
    end
    return true
end

