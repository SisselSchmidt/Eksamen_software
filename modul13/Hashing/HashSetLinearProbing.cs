using Hashing;

public class HashSetLinearProbing : HashSet {
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength) {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    /**
     * Tests om den indeholder x.
     * @param x et object
     * @return true if x er et element af dette sæt
     */
    public bool Contains(Object x) {
        int index = hashValue(x);
        int begin = index;
        Object current = buckets[index];
        while (current != null && !current.Equals(x) && begin != index) {
            index = (index + 1) % buckets.Length;
            current = buckets[index];
        }
        return current != null && current.Equals(x);
    }

    /**
     * Tilføjer element.
     * @param x et object
     * @return true hvis x er et nyt objekt, false hvis x allerede var i sættet
     */
    public bool Add(Object x) {
        rehashIfNecessary();
        
        int h = hashValue(x);
        Object current = buckets[h];
        if (current == null) {
            buckets[h] = x;
        } else {
            int index = h;
            while (current != null && !State.DELETED.Equals(current)) {
                index = (index + 1) % buckets.Length;
                current = buckets[index];
            }
            buckets[index] = x;
        }
        currentSize++;
        
        return true;
    }
     private void rehashIfNecessary() {
        double loadFactor = currentSize / (double) buckets.Length;
        if (loadFactor >= 0.75) {
            Console.WriteLine("We need to rehash!");
            currentSize = 0;
            Object[] oldBucket = this.buckets;
            this.buckets = new Object[this.buckets.Length * 2];

            for (int i = 0; i < oldBucket.Length; i++) {
                Object temp = oldBucket[i];
                if (temp != null) {
                    Add(temp);
                }
            }
        }  
    }

   /**
     * Fjerner et obejkt
     * @param x er object
     * @return true hvis x den er fjernet fra sættet, false hvis x den ikke er et element af sættet
     */
    public bool Remove(Object x) {
        int index = hashValue(x);
        Object current = buckets[index];
        while (current != null && !current.Equals(x)) {
            index = (index + 1) % buckets.Length;
            current = buckets[index];
        }
        
        if (current != null && current.Equals(x)) {
            buckets[index] = State.DELETED;
            currentSize--;
            return true;
        } else {
            return false;
        }
    }


    /**
     * henter antal elementer i sættet.
     * @return antallet af elements
     */
    public int Size() {
        return currentSize;
    }

     private int hashValue(Object x) {
        int h = x.GetHashCode();
        if (h < 0) {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public override String ToString() {
        String result = "";
        for (int i = 0; i < buckets.Length; i++) {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ? 
                    hashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
